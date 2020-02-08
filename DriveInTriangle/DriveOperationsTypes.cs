///////////////////////////////////////////////////////////////////////////////
// Activity: program.activity0
// DriveOperations type definitions
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

namespace Robotics.DriveInTriangle.DriveOperations
{
    static class Contract
    {
        public const string Identifier = "http://schemas.microsoft.com/2013/08/driveintriangle/driveoperations.html";
    }

    [dssa.DataContract]
    public class DriveOperationsState
    {
    }

    #region Custom message types

    [dssa.DataContract]
    public class DriveRequest
    {
        double _distance;
        [dssa.DataMember]
        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        double _power;
        [dssa.DataMember]
        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }
    }

    [dssa.DataContract]
    public class DriveResponse
    {
        int _status;
        [dssa.DataMember]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }

    [dssa.DataContract]
    public class RotateRequest
    {
        double _degrees;
        [dssa.DataMember]
        public double Degrees
        {
            get { return _degrees; }
            set { _degrees = value; }
        }

        double _power;
        [dssa.DataMember]
        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }
    }

    [dssa.DataContract]
    public class RotateResponse
    {
        int _status;
        [dssa.DataMember]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }

    #endregion

    #region Operations Port

    public class DriveOperationsOperations : ccr.PortSet
    {
        public DriveOperationsOperations() : base (
            typeof(dssp.DsspDefaultLookup),
            typeof(dssp.DsspDefaultDrop),
            typeof(dssh.HttpGet),
            typeof(Drive),
            typeof(Rotate),
            typeof(Get),
            typeof(Replace),
            typeof(Subscribe)
        )
        {
        }

        public static implicit operator ccr.Port<dssp.DsspDefaultLookup>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<dssp.DsspDefaultLookup>)portSet[typeof(dssp.DsspDefaultLookup)];
        }

        public void Post(dssp.DsspDefaultLookup msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<dssp.DsspDefaultDrop>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<dssp.DsspDefaultDrop>)portSet[typeof(dssp.DsspDefaultDrop)];
        }

        public void Post(dssp.DsspDefaultDrop msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<Get>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<Get>)portSet[typeof(Get)];
        }

        public void Post(Get msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<Replace>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<Replace>)portSet[typeof(Replace)];
        }

        public void Post(Replace msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<Subscribe>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<Subscribe>)portSet[typeof(Subscribe)];
        }

        public void Post(Subscribe msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<Drive>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<Drive>)portSet[typeof(Drive)];
        }

        public void Post(Drive msg)
        {
            base.PostUnknownType(msg);
        }

        public static implicit operator ccr.Port<Rotate>(DriveOperationsOperations portSet)
        {
            if (portSet == null)
            {
                return null;
            }
            return (ccr.Port<Rotate>)portSet[typeof(Rotate)];
        }

        public void Post(Rotate msg)
        {
            base.PostUnknownType(msg);
        }

        public dssp.DsspResponsePort<DriveResponse> Drive(DriveRequest body)
        {
            Drive message = new Drive();
            message.Body = body;

            this.Post(message);

            return message.ResponsePort;
        }

        public dssp.DsspResponsePort<RotateResponse> Rotate(RotateRequest body)
        {
            Rotate message = new Rotate();
            message.Body = body;

            this.Post(message);

            return message.ResponsePort;
        }

        public dssp.DsspResponsePort<dssp.SubscribeResponseType> Subscribe(ccr.IPort notificationPort)
        {
            Subscribe message = new Subscribe();
            message.NotificationPort = notificationPort;

            this.Post(message);

            return message.ResponsePort;
        }
    }

    #endregion

    #region Standard DSSP message definitions

    [Description("Retrieves the current state of the service")]
    public class Get : dssp.Get<dssp.GetRequestType, dssp.DsspResponsePort<DriveOperationsState>>
    {
    }

    [Description("Sets the current state of the service.\nThis is raised as an event whenever the state changes.")]
    public class Replace : dssp.Replace<DriveOperationsState, dssp.DsspResponsePort<dssp.DefaultReplaceResponseType>>
    {
    }

    public class Subscribe : dssp.Subscribe<dssp.SubscribeRequestType, dssp.DsspResponsePort<dssp.SubscribeResponseType>>
    {
    }

    #endregion

    #region Custom message definitions

    public class Drive : dssp.Submit<DriveRequest, dssp.DsspResponsePort<DriveResponse>>
    {
    }

    public class Rotate : dssp.Submit<RotateRequest, dssp.DsspResponsePort<RotateResponse>>
    {
    }

    #endregion
}
