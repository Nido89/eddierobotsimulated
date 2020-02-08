///////////////////////////////////////////////////////////////////////////////
// Activity: program.activity0
// DriveOperations service implementation
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

using ccr = Microsoft.Ccr.Core;
using dss = Microsoft.Dss.Core;
using dssa = Microsoft.Dss.Core.Attributes;
using dssh = Microsoft.Dss.Core.DsspHttp;
using dssm = Microsoft.Dss.ServiceModel.DsspServiceBase;
using dssp = Microsoft.Dss.ServiceModel.Dssp;
using soap = W3C.Soap;

using submgr = Microsoft.Dss.Services.SubscriptionManager;
using drive = Microsoft.Robotics.Services.Drive.Proxy;
using waitfordrivecompletion = Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy;

namespace Robotics.DriveInTriangle.DriveOperations
{
    [DisplayName("DriveInTriangle DriveOperations")]
    [Description("A user defined activity.")]
    [dssa.Contract(Contract.Identifier)]
    public class DriveOperationsService : dssm.DsspServiceBase
    {
        // Service state
        [dssa.InitialStatePartner(Optional = true)]
        private DriveOperationsState _state;

        // Service operations port
        [dssa.ServicePort("/DriveInTriangle/DriveOperations", AllowMultipleInstances = true)]
        private DriveOperationsOperations _mainPort = new DriveOperationsOperations();

        #region Partner services

        [dssa.Partner("SubMgr", Contract = submgr.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.CreateAlways)]
        private submgr.SubscriptionManagerPort _subMgr = new submgr.SubscriptionManagerPort();

        // Partner: GenericDifferentialDrive, Contract: http://schemas.microsoft.com/robotics/2006/05/drive.html
        [dssa.Partner("GenericDifferentialDrive", Contract = drive.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.UsePartnerListEntry)]
        drive.DriveOperations _genericDifferentialDrivePort = new drive.DriveOperations();

        // Partner: WaitForDriveCompletion, Contract: http://schemas.microsoft.com/robotics/2008/09/waitfordrivecompletion.html
        [dssa.Partner("WaitForDriveCompletion", Contract = waitfordrivecompletion.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.UsePartnerListEntry)]
        waitfordrivecompletion.WaitForDriveCompletionOperations _waitForDriveCompletionPort = new waitfordrivecompletion.WaitForDriveCompletionOperations();

        #endregion

        public DriveOperationsService(dssp.DsspServiceCreationPort creationPort)
            : base(creationPort)
        {
        }

        protected override void Start()
        {
            // If there was no initial state partner, then the service state will be null.
            if (_state == null)
            {
                // The state MUST be created before the service starts processing messages.
                _state = new DriveOperationsState();
            }

            // The rest of the start process requires the ability to wait for responses from
            // services and from the start handler (if any). So execution now proceeds in an
            // iterator function.
            SpawnIterator(DoStart);
        }

        private IEnumerator<ccr.ITask> DoStart()
        {

            // Start operation handlers and insert into directory service.
            StartHandlers();

            yield break;
        }

        private void StartHandlers()
        {
            // Activate message handlers for this service and insert into the directory.
            base.Start();
        }

        #region Standard DSS message handlers

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Concurrent)]
        public virtual IEnumerator<ccr.ITask> GetHandler(Get get)
        {
            get.ResponsePort.Post(_state);
            yield break;
        }

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Concurrent)]
        public virtual IEnumerator<ccr.ITask> HttpGetHandler(dssh.HttpGet httpGet)
        {
            httpGet.ResponsePort.Post(new dssh.HttpResponseType(_state));
            yield break;
        }

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Exclusive)]
        public virtual IEnumerator<ccr.ITask> ReplaceHandler(Replace replace)
        {
            _state = replace.Body;

            replace.ResponsePort.Post(dssp.DefaultReplaceResponseType.Instance);
            base.SendNotification<Replace>(_subMgr, replace);

            yield break;
        }

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Concurrent)]
        public virtual IEnumerator<ccr.ITask> SubscribeHandler(Subscribe subscribe)
        {
            dssp.SubscribeRequestType request = subscribe.Body;

            yield return ccr.Arbiter.Choice(
                SubscribeHelper(_subMgr, request, subscribe.ResponsePort),
                delegate(ccr.SuccessResult success)
                {
                    base.SendNotificationToTarget<Replace>(request.Subscriber, _subMgr, _state);
                },
                delegate(Exception e) { }
            );
        }

        #endregion

        #region Custom message handlers

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Independent)]
        public virtual IEnumerator<ccr.ITask> DriveHandler(Drive message)
        {
            DriveMessageHandler handler = new DriveMessageHandler(this, Environment.TaskQueue);
            return handler.RunHandler(message.Body, message.ResponsePort);
        }

        [dssa.ServiceHandler(dssa.ServiceHandlerBehavior.Independent)]
        public virtual IEnumerator<ccr.ITask> RotateHandler(Rotate message)
        {
            RotateMessageHandler handler = new RotateMessageHandler(this, Environment.TaskQueue);
            return handler.RunHandler(message.Body, message.ResponsePort);
        }

        #endregion

        #region DriveMessageHandler class

        class DriveMessageHandler : HandlerBase
        {
            ///////////////////////////////////////////////////////////////////
            // __use__.snippet.snippet.noop - [(__use__.snippet.snippet.expr1 - __use__.snippet.snippet.join)(__use__.snippet.snippet.expr0 - &__use__.snippet.snippet.join)(__use__.snippet.snippet.expr - &__use__.snippet.snippet.join)] - __use__.snippet.call - __use__.snippet.call.iftype
            // __use__0.snippet.call - __use__0.snippet.call.iftype
            // [(snippet.snippet.noop - snippet.snippet.expr - snippet.snippet.join)] - snippet.element
            ///////////////////////////////////////////////////////////////////

            public DriveMessageHandler(DriveOperationsService service, ccr.DispatcherQueue queue)
                : base(service, queue)
            {
            }

            dssp.DsspResponsePort<DriveResponse> _responsePort;

            ///////////////////////////////////////////////////////////////////
            // __use__.snippet.snippet.noop - [(__use__.snippet.snippet.expr1 - __use__.snippet.snippet.join)(__use__.snippet.snippet.expr0 - &__use__.snippet.snippet.join)(__use__.snippet.snippet.expr - &__use__.snippet.snippet.join)] - __use__.snippet.call - __use__.snippet.call.iftype
            ///////////////////////////////////////////////////////////////////

            public IEnumerator<ccr.ITask> RunHandler(DriveRequest message, dssp.DsspResponsePort<DriveResponse> responsePort)
            {
                _responsePort = responsePort;
                Increment();

                drive.DriveDistanceRequest request = new drive.DriveDistanceRequest();
                request.DriveDistanceStage = Microsoft.Robotics.Services.Drive.Proxy.DriveStage.InitialRequest;
                request.Power = message.Power;
                request.Distance = message.Distance;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        GenericDifferentialDrivePort.DriveDistance(request),
                        OnDriveDistanceSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"GenericDifferentialDrivePort.DriveDistance(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();

                yield return WaitUntilComplete();
            }

            void OnDriveDistanceSuccess(dssp.DefaultUpdateResponseType response)
            {

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        WaitForDriveCompletionPort.Wait(new waitfordrivecompletion.WaitRequestType()),
                        OnWaitRequestTypeSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"WaitForDriveCompletionPort.Wait(new waitfordrivecompletion.WaitRequestType())");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnWaitRequestTypeSuccess(waitfordrivecompletion.WaitResponseType response)
            {
                DriveResponse responseA = new DriveResponse();
                responseA.Status = IntCast(response);
                _responsePort.Post(responseA);

                Decrement();
            }

            class JoinAlpha
            {
                public string Distance;
                public string Power;
                public string DriveDistanceStage;

                public JoinAlpha()
                {
                }

                public JoinAlpha(object[] args)
                {
                    Distance = args[0].ToString();
                    Power = args[1].ToString();
                    DriveDistanceStage = args[2].ToString();
                }
            }

            ccr.Port<object>[] _joinAlphaPorts = new ccr.Port<object>[3]{
                new ccr.Port<object>(),
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            class JoinBeta
            {
                public string Status;

                public JoinBeta()
                {
                }

                public JoinBeta(object[] args)
                {
                    Status = args[0].ToString();
                }
            }

            ccr.Port<object>[] _joinBetaPorts = new ccr.Port<object>[1]{
                new ccr.Port<object>()
            };
        }

        #endregion

        #region RotateMessageHandler class

        class RotateMessageHandler : HandlerBase
        {
            ///////////////////////////////////////////////////////////////////
            // __use__.snippet0.snippet.noop - [(__use__.snippet0.snippet.expr1 - __use__.snippet0.snippet.join)(__use__.snippet0.snippet.expr0 - &__use__.snippet0.snippet.join)(__use__.snippet0.snippet.expr - &__use__.snippet0.snippet.join)] - __use__.snippet0.call - __use__.snippet0.call.iftype
            // __use__0.snippet.call - __use__0.snippet.call.iftype
            // [(snippet.snippet.noop - snippet.snippet.expr - snippet.snippet.join)] - snippet.element
            ///////////////////////////////////////////////////////////////////

            public RotateMessageHandler(DriveOperationsService service, ccr.DispatcherQueue queue)
                : base(service, queue)
            {
            }

            dssp.DsspResponsePort<RotateResponse> _responsePort;

            ///////////////////////////////////////////////////////////////////
            // __use__.snippet0.snippet.noop - [(__use__.snippet0.snippet.expr1 - __use__.snippet0.snippet.join)(__use__.snippet0.snippet.expr0 - &__use__.snippet0.snippet.join)(__use__.snippet0.snippet.expr - &__use__.snippet0.snippet.join)] - __use__.snippet0.call - __use__.snippet0.call.iftype
            ///////////////////////////////////////////////////////////////////

            public IEnumerator<ccr.ITask> RunHandler(RotateRequest message, dssp.DsspResponsePort<RotateResponse> responsePort)
            {
                _responsePort = responsePort;
                Increment();

                drive.RotateDegreesRequest request = new drive.RotateDegreesRequest();
                request.RotateDegreesStage = Microsoft.Robotics.Services.Drive.Proxy.DriveStage.InitialRequest;
                request.Power = message.Power;
                request.Degrees = message.Degrees;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        GenericDifferentialDrivePort.RotateDegrees(request),
                        OnRotateDegreesSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"GenericDifferentialDrivePort.RotateDegrees(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();

                yield return WaitUntilComplete();
            }

            void OnRotateDegreesSuccess(dssp.DefaultUpdateResponseType response)
            {

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        WaitForDriveCompletionPort.Wait(new waitfordrivecompletion.WaitRequestType()),
                        OnWaitRequestTypeSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"WaitForDriveCompletionPort.Wait(new waitfordrivecompletion.WaitRequestType())");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnWaitRequestTypeSuccess(waitfordrivecompletion.WaitResponseType response)
            {
                RotateResponse responseA = new RotateResponse();
                responseA.Status = IntCast(response);
                _responsePort.Post(responseA);

                Decrement();
            }

            class JoinAlpha
            {
                public string Degrees;
                public string Power;
                public string RotateDegreesStage;

                public JoinAlpha()
                {
                }

                public JoinAlpha(object[] args)
                {
                    Degrees = args[0].ToString();
                    Power = args[1].ToString();
                    RotateDegreesStage = args[2].ToString();
                }
            }

            ccr.Port<object>[] _joinAlphaPorts = new ccr.Port<object>[3]{
                new ccr.Port<object>(),
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            class JoinBeta
            {
                public string Status;

                public JoinBeta()
                {
                }

                public JoinBeta(object[] args)
                {
                    Status = args[0].ToString();
                }
            }

            ccr.Port<object>[] _joinBetaPorts = new ccr.Port<object>[1]{
                new ccr.Port<object>()
            };
        }

        #endregion

        #region Handler utility base class

        class HandlerBase : ccr.CcrServiceBase
        {
            ccr.Port<ccr.EmptyValue> _complete = new ccr.Port<ccr.EmptyValue>();
            ccr.Port<ccr.EmptyValue> _shutdown = new ccr.Port<ccr.EmptyValue>();
            List<ccr.Port<object>[]> _joins = new List<ccr.Port<object>[]>();
            DriveOperationsService _service;
            int _count;

            public HandlerBase(DriveOperationsService service, ccr.DispatcherQueue queue)
                : base(queue)
            {
                _service = service;
            }

            protected DriveOperationsState State
            {
                get { return _service._state; }
            }

            bool _stateChanged;

            public bool StateChanged
            {
                get { return _stateChanged; }
                set { _stateChanged = value; }
            }

            protected drive.DriveOperations GenericDifferentialDrivePort
            {
                get { return _service._genericDifferentialDrivePort; }
            }

            protected waitfordrivecompletion.WaitForDriveCompletionOperations WaitForDriveCompletionPort
            {
                get { return _service._waitForDriveCompletionPort; }
            }

            public ccr.Port<ccr.EmptyValue> Complete
            {
                get { return _complete; }
            }

            protected void Increment()
            {
                System.Threading.Interlocked.Increment(ref _count);
            }

            protected void Decrement()
            {
                int offset = 0;

                foreach (ccr.Port<object>[] join in _joins)
                {
                    bool complete = true;
                    int joinCount = 0;

                    foreach (ccr.Port<object> sink in join)
                    {
                        if (sink.ItemCount != 0)
                        {
                            joinCount += sink.ItemCount;
                        }
                        else
                        {
                            complete = false;
                        }
                    }
                    if (complete == false)
                    {
                        offset += joinCount;
                    }
                }

                if (System.Threading.Interlocked.Decrement(ref _count) <= offset)
                {
                    _shutdown.Post(ccr.EmptyValue.SharedInstance);
                    _complete.Post(ccr.EmptyValue.SharedInstance);
                }
            }

            protected void Decrement(int count)
            {
                for(int i = 0; i < count; i++)
                {
                    Decrement();
                }
            }

            protected void RegisterJoin(ccr.Port<object>[] join)
            {
                _joins.Add(join);
            }

            protected ccr.ITask WaitUntilComplete()
            {
                return ccr.Arbiter.Receive(false, _shutdown, NullDelegate);
            }

            protected static void NullDelegate(ccr.EmptyValue token)
            {
            }

            protected void SendNotification<T>(object notification)
                where T : dssp.DsspOperation, new()
            {
                _service.SendNotification<T>(_service._subMgr, notification);
            }

            protected void FaultHandler(soap.Fault fault, string msg)
            {
                _service.LogError(null, msg, fault);
            }

            protected static string Stringize(object obj)
            {
                if (obj == null)
                {
                    return string.Empty;
                }
                else
                {
                    return obj.ToString();
                }
            }

            protected void UnhandledResponse(W3C.Soap.Fault fault)
            {
                _service.LogError("Unhandled fault response from partner service", fault);
                Decrement();
            }

            protected void UnhandledResponse<T>(T response)
            {
                Decrement();
            }

            #region Type Cast Functions

            protected static bool BoolCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToBoolean(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return false;
            }

            protected static byte ByteCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToByte(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static char CharCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToChar(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return '\0';
            }

            protected static decimal DecimalCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToDecimal(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static double DoubleCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToDouble(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static float FloatCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToSingle(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static int IntCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToInt32(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static long LongCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToInt64(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static sbyte SByteCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToSByte(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static short ShortCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToInt16(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static uint UIntCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToUInt32(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static ulong ULongCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToUInt64(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            protected static ushort UShortCast(object obj)
            {
                if (obj != null && obj is IConvertible)
                {
                    try
                    {
                        return ((IConvertible)obj).ToUInt16(System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return 0;
            }

            #endregion

            #region List Functions

            protected List<T> ListAdd<T>(List<T> list, T item)
            {
                List<T> output = new List<T>(list);
                output.Add(item);
                return output;
            }

            protected List<T> ListConcat<T>(List<T> head, List<T> tail)
            {
                List<T> output = new List<T>(head);
                output.AddRange(tail);
                return output;
            }

            protected int ListIndex<T>(List<T> list, T item)
            {
                return list.IndexOf(item);
            }

            protected List<T> ListRemove<T>(List<T> list, int index)
            {
                List<T> output = new List<T>(list);
                output.RemoveAt(index);
                return output;
            }

            protected List<T> ListReverse<T>(List<T> list)
            {
                List<T> output = new List<T>(list);
                output.Reverse();
                return output;
            }

            protected List<T> ListSort<T>(List<T> list)
            {
                List<T> output = new List<T>(list);
                output.Sort();
                return output;
            }

            protected List<T> ListInsert<T>(List<T> list, T item, int index)
            {
                List<T> output = new List<T>(list);
                output.Insert(index, item);
                return output;
            }

            #endregion
        }

        #endregion
    }
}
