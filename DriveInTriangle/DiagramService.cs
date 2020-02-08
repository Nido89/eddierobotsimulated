///////////////////////////////////////////////////////////////////////////////
// Activity: program.activity
// Diagram service implementation
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
using dialog = Microsoft.Robotics.Services.Sample.Dialog.Proxy;
using waitfordrivecompletion = Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy;

namespace Robotics.DriveInTriangle.Diagram
{
    [DisplayName("DriveInTriangle")]
    [Description("A user defined activity.")]
    [dssa.Contract(Contract.Identifier)]
    public class DiagramService : dssm.DsspServiceBase
    {
        // Service state
        [dssa.InitialStatePartner(Optional = true)]
        private DiagramState _state;

        // Service operations port
        [dssa.ServicePort("/DriveInTriangle", AllowMultipleInstances = true)]
        private DiagramOperations _mainPort = new DiagramOperations();

        #region Partner services

        [dssa.Partner("SubMgr", Contract = submgr.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.CreateAlways)]
        private submgr.SubscriptionManagerPort _subMgr = new submgr.SubscriptionManagerPort();

        // Partner: WaitForDriveCompletion, Contract: http://schemas.microsoft.com/robotics/2008/09/waitfordrivecompletion.html
        [dssa.Partner("WaitForDriveCompletion", Contract = waitfordrivecompletion.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.UsePartnerListEntry)]
        waitfordrivecompletion.WaitForDriveCompletionOperations _waitForDriveCompletionPort = new waitfordrivecompletion.WaitForDriveCompletionOperations();
        waitfordrivecompletion.WaitForDriveCompletionOperations _waitForDriveCompletionNotify = new waitfordrivecompletion.WaitForDriveCompletionOperations();

        // Partner: SimpleDialog, Contract: http://schemas.microsoft.com/robotics/2006/08/dialog.html
        [dssa.Partner("SimpleDialog", Contract = dialog.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.UsePartnerListEntry)]
        dialog.DialogOperations _simpleDialogPort = new dialog.DialogOperations();

        // Partner: DriveOperations, Contract: 
        [dssa.Partner("DriveOperations", Contract = DriveOperations.Contract.Identifier, CreationPolicy = dssa.PartnerCreationPolicy.UseExistingOrCreate)]
        DriveOperations.DriveOperationsOperations _driveOperationsPort = new DriveOperations.DriveOperationsOperations();

        #endregion

        public DiagramService(dssp.DsspServiceCreationPort creationPort)
            : base(creationPort)
        {
        }

        protected override void Start()
        {
            // If there was no initial state partner, then the service state will be null.
            if (_state == null)
            {
                // The state MUST be created before the service starts processing messages.
                _state = new DiagramState();
            }

            // The rest of the start process requires the ability to wait for responses from
            // services and from the start handler (if any). So execution now proceeds in an
            // iterator function.
            SpawnIterator(DoStart);
        }

        private IEnumerator<ccr.ITask> DoStart()
        {
            soap.Fault fault = null;

            // Subscribe to partners

            yield return ccr.Arbiter.Choice(
                _waitForDriveCompletionPort.Subscribe(_waitForDriveCompletionNotify,                
                    typeof(Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy.Replace)
                ),
                EmptyHandler,
                delegate(soap.Fault f)
                {
                    fault = f;
                }
            );

            if (fault != null)
            {
                LogError("Failed to subscribe to program.WaitForDriveCompletionService.WaitForDriveCompletion", fault);
                StartFailed();
                yield break;
            }

            // Start the RunHandler, this represents the parts of the diagram that
            // are are not run in the context of an operation or notification.
            StartHandler start = new StartHandler(this, Environment.TaskQueue);
            SpawnIterator(start.RunHandler);
            // Wait until the RunHandler has completed.
            yield return ccr.Arbiter.Receive(false, start.Complete, EmptyHandler);

            // Start operation handlers and insert into directory service.
            StartHandlers();

            // Add notifications to the main interleave
            base.MainPortInterleave.CombineWith(
                new ccr.Interleave(
                    new ccr.ExclusiveReceiverGroup(
                    ),
                    new ccr.ConcurrentReceiverGroup(
                    )
                )
            );

            // Activate independent tasks
            Activate<ccr.ITask>(
                ccr.Arbiter.ReceiveWithIterator<Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy.Replace>(true, _waitForDriveCompletionNotify, WaitForDriveCompletionReplaceHandler)
            );

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
        public virtual IEnumerator<ccr.ITask> ActionHandler(Action message)
        {
            // Empty handler. Respond with default response type.
            message.ResponsePort.Post(new ActionResponse());
            yield break;
        }

        #endregion

        #region Notification message handlers

        IEnumerator<ccr.ITask> WaitForDriveCompletionReplaceHandler(Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy.Replace message)
        {
            OnWaitForDriveCompletionReplaceHandler handler = new OnWaitForDriveCompletionReplaceHandler(this, Environment.TaskQueue);
            return handler.RunHandler(message);
        }

        #endregion

        #region OnWaitForDriveCompletionReplaceHandler class

        class OnWaitForDriveCompletionReplaceHandler : HandlerBase
        {
            ///////////////////////////////////////////////////////////////////
            // __use__30.snippet0.snippet.noop - __use__30.snippet0.snippet.expr - __use__30.snippet0.snippet.join
            // __use__30.snippet0.call - __use__30.snippet0.call.iftype
            ///////////////////////////////////////////////////////////////////

            public OnWaitForDriveCompletionReplaceHandler(DiagramService service, ccr.DispatcherQueue queue)
                : base(service, queue)
            {

                RegisterAndActivateJoins();
            }

            ///////////////////////////////////////////////////////////////////
            // __use__30.snippet0.snippet.noop - __use__30.snippet0.snippet.expr - __use__30.snippet0.snippet.join
            ///////////////////////////////////////////////////////////////////

            public IEnumerator<ccr.ITask> RunHandler(Microsoft.Dss.Services.Samples.WaitForDriveCompletion.Proxy.Replace message)
            {
                Increment();

                Increment();
                _joinAlphaPorts[0].Post(message.Body.LastStatus);

                Decrement();

                yield return WaitUntilComplete();
            }

            ///////////////////////////////////////////////////////////////////
            // __use__30.snippet0.call - __use__30.snippet0.call.iftype
            ///////////////////////////////////////////////////////////////////

            void _joinAlphaHandler(object[] args)
            {
                JoinAlpha message = new JoinAlpha(args);
                SimpleDialogPort.Alert((dialog.AlertRequest)message);

                Decrement(args.Length);
            }

            class JoinAlpha
            {
                public Microsoft.Robotics.Services.Drive.Proxy.DriveStage Message;

                public JoinAlpha()
                {
                }

                public JoinAlpha(object[] args)
                {
                    Message = (Microsoft.Robotics.Services.Drive.Proxy.DriveStage)args[0];
                }

                public static explicit operator dialog.AlertRequest(JoinAlpha join)
                {
                    dialog.AlertRequest request = new dialog.AlertRequest();

                    request.Message = HandlerBase.Stringize(join.Message);
                    return request;
                }
            }

            ccr.Port<object>[] _joinAlphaPorts = new ccr.Port<object>[1]{
                new ccr.Port<object>()
            };

            void RegisterAndActivateJoins()
            {
                // Register joins with base class to manage active count for incomplete joins.
                base.RegisterJoin(_joinAlphaPorts);
                // Activate Join handlers
                Activate(ccr.Arbiter.MultiplePortReceive(true, _joinAlphaPorts, _joinAlphaHandler));
            }
        }

        #endregion

        #region StartHandler class

        class StartHandler : HandlerBase
        {
            ///////////////////////////////////////////////////////////////////
            // program.activity.Start+start
            // [(expr - __use__3.snippet0.snippet.noop - __use__3.snippet0.snippet.expr - __use__3.snippet0.snippet.join)] - __use__3.snippet0.call - __use__3.snippet0.call.iftype
            // __use__4.snippet0.snippet.noop - [(__use__4.snippet0.snippet.expr0 - __use__4.snippet0.snippet.join)(__use__4.snippet0.snippet.expr - &__use__4.snippet0.snippet.join)] - __use__4.snippet0.call - __use__4.snippet0.call.iftype
            // __use__.snippet0.snippet.noop - [(__use__.snippet0.snippet.expr0 - __use__.snippet0.snippet.join)(__use__.snippet0.snippet.expr - &__use__.snippet0.snippet.join)] - __use__.snippet0.call - __use__.snippet0.call.iftype
            // __use__40.snippet0.snippet.noop - [(__use__40.snippet0.snippet.expr0 - __use__40.snippet0.snippet.join)(__use__40.snippet0.snippet.expr - &__use__40.snippet0.snippet.join)] - __use__40.snippet0.call - __use__40.snippet0.call.iftype
            // __use__0.snippet0.snippet.noop - [(__use__0.snippet0.snippet.expr0 - __use__0.snippet0.snippet.join)(__use__0.snippet0.snippet.expr - &__use__0.snippet0.snippet.join)] - __use__0.snippet0.call - __use__0.snippet0.call.iftype
            // __use__400.snippet0.snippet.noop - [(__use__400.snippet0.snippet.expr0 - __use__400.snippet0.snippet.join)(__use__400.snippet0.snippet.expr - &__use__400.snippet0.snippet.join)] - __use__400.snippet0.call - __use__400.snippet0.call.iftype
            // __use__00.snippet0.snippet.noop - [(__use__00.snippet0.snippet.expr0 - __use__00.snippet0.snippet.join)(__use__00.snippet0.snippet.expr - &__use__00.snippet0.snippet.join)] - __use__00.snippet0.call - __use__00.snippet0.call.iftype
            // snippet.element
            ///////////////////////////////////////////////////////////////////

            public StartHandler(DiagramService service, ccr.DispatcherQueue queue)
                : base(service, queue)
            {
            }

            ///////////////////////////////////////////////////////////////////
            // program.activity.Start+start
            // snippet.element
            // [(expr - __use__3.snippet0.snippet.noop - __use__3.snippet0.snippet.expr - __use__3.snippet0.snippet.join)] - __use__3.snippet0.call - __use__3.snippet0.call.iftype
            ///////////////////////////////////////////////////////////////////

            public IEnumerator<ccr.ITask> RunHandler()
            {
                Increment();

                dialog.AlertRequest request = new dialog.AlertRequest();
                request.Message = @"Click OK to start";

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        SimpleDialogPort.Alert(request),
                        OnAlertSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"SimpleDialogPort.Alert(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();

                yield return WaitUntilComplete();
            }

            void OnAlertSuccess(dssp.DefaultSubmitResponseType response)
            {
                DriveOperations.DriveRequest request = new DriveOperations.DriveRequest();
                request.Power = 0.5D;
                request.Distance = 0.5D;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Drive(request),
                        OnDriveSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Drive(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnDriveSuccess(DriveOperations.DriveResponse response)
            {
                DriveOperations.RotateRequest request = new DriveOperations.RotateRequest();
                request.Power = 0.5D;
                request.Degrees = (double)120;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Rotate(request),
                        OnRotateSuccess,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Rotate(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnRotateSuccess(DriveOperations.RotateResponse response)
            {
                DriveOperations.DriveRequest request = new DriveOperations.DriveRequest();
                request.Power = 0.5D;
                request.Distance = 0.5D;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Drive(request),
                        OnDrive1Success,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Drive(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnDrive1Success(DriveOperations.DriveResponse response)
            {
                DriveOperations.RotateRequest request = new DriveOperations.RotateRequest();
                request.Power = 0.5D;
                request.Degrees = (double)120;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Rotate(request),
                        OnRotate1Success,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Rotate(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnRotate1Success(DriveOperations.RotateResponse response)
            {
                DriveOperations.DriveRequest request = new DriveOperations.DriveRequest();
                request.Power = 0.5D;
                request.Distance = 0.5D;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Drive(request),
                        OnDrive2Success,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Drive(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnDrive2Success(DriveOperations.DriveResponse response)
            {
                DriveOperations.RotateRequest request = new DriveOperations.RotateRequest();
                request.Power = 0.5D;
                request.Degrees = (double)120;

                Increment();
                Activate(
                    ccr.Arbiter.Choice(
                        DriveOperationsPort.Rotate(request),
                        OnRotate2Success,
                        delegate(soap.Fault fault)
                        {
                            base.FaultHandler(fault, @"DriveOperationsPort.Rotate(request)");
                            Decrement();
                        }
                    )
                );

                Decrement();
            }

            void OnRotate2Success(DriveOperations.RotateResponse response)
            {
                Decrement();
            }

            class JoinAlpha
            {
                public string Message;

                public JoinAlpha()
                {
                }

                public JoinAlpha(object[] args)
                {
                    Message = args[0].ToString();
                }
            }

            ccr.Port<object>[] _joinAlphaPorts = new ccr.Port<object>[1]{
                new ccr.Port<object>()
            };

            class JoinBeta
            {
                public string Distance;
                public string Power;

                public JoinBeta()
                {
                }

                public JoinBeta(object[] args)
                {
                    Distance = args[0].ToString();
                    Power = args[1].ToString();
                }
            }

            ccr.Port<object>[] _joinBetaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            class JoinGamma
            {
                public string Degrees;
                public string Power;

                public JoinGamma()
                {
                }

                public JoinGamma(object[] args)
                {
                    Degrees = args[0].ToString();
                    Power = args[1].ToString();
                }
            }

            ccr.Port<object>[] _joinGammaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            ccr.Port<object>[] _secondJoinBetaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            ccr.Port<object>[] _secondJoinGammaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            ccr.Port<object>[] _thirdJoinBetaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
                new ccr.Port<object>()
            };

            ccr.Port<object>[] _thirdJoinGammaPorts = new ccr.Port<object>[2]{
                new ccr.Port<object>(),
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
            DiagramService _service;
            int _count;

            public HandlerBase(DiagramService service, ccr.DispatcherQueue queue)
                : base(queue)
            {
                _service = service;
            }

            protected DiagramState State
            {
                get { return _service._state; }
            }

            bool _stateChanged;

            public bool StateChanged
            {
                get { return _stateChanged; }
                set { _stateChanged = value; }
            }

            protected waitfordrivecompletion.WaitForDriveCompletionOperations WaitForDriveCompletionPort
            {
                get { return _service._waitForDriveCompletionPort; }
            }

            protected dialog.DialogOperations SimpleDialogPort
            {
                get { return _service._simpleDialogPort; }
            }

            protected DriveOperations.DriveOperationsOperations DriveOperationsPort
            {
                get { return _service._driveOperationsPort; }
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
