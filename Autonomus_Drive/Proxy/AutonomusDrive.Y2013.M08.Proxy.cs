//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Reflection.AssemblyVersionAttribute("0.0.0.0")]
[assembly: global::Microsoft.Dss.Core.Attributes.ServiceDeclarationAttribute(global::Microsoft.Dss.Core.Attributes.DssServiceDeclaration.Proxy, SourceAssemblyKey="AutonomusDrive.Y2013.M08, Version=0.0.0.0, Culture=neutral, PublicKeyToken=779fc1" +
    "78f5d07eb3")]
[assembly: global::System.Security.SecurityTransparentAttribute()]
[assembly: global::System.Security.SecurityRulesAttribute(global::System.Security.SecurityRuleSet.Level1)]

namespace Robotics.AutonomusDrive.Diagram.Proxy {
    
    
    [global::Microsoft.Dss.Core.Attributes.DataContractAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html")]
    [global::System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", ElementName="ActionRequest")]
    public class ActionRequest : global::Microsoft.Dss.Core.IDssSerializable, global::System.ICloneable {
        
        public ActionRequest() {
        }
        
        /// <summary>
        ///Copies the data member values of the current ActionRequest to the specified target object
        ///</summary>
        ///<param name="target">target object (must be an instance of)</param>
        public virtual void CopyTo(Microsoft.Dss.Core.IDssSerializable target) {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest typedTarget = ((global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest)(target));
        }
        
        /// <summary>
        ///Clones ActionRequest
        ///</summary>
        ///<returns>cloned value</returns>
        public virtual object Clone() {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest target0 = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest();
            this.CopyTo(target0);
            return target0;
        }
        
        /// <summary>
        ///Serializes the data member values of the current ActionRequest to the specified writer
        ///</summary>
        ///<param name="writer">the writer to which to serialize</param>
        public virtual void Serialize(System.IO.BinaryWriter writer) {
        }
        
        /// <summary>
        ///Deserializes ActionRequest
        ///</summary>
        ///<param name="reader">the reader from which to deserialize</param>
        ///<returns>deserialized ActionRequest</returns>
        public virtual object Deserialize(System.IO.BinaryReader reader) {
            return this;
        }
    }
    
    [global::Microsoft.Dss.Core.Attributes.DataContractAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html")]
    [global::System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", ElementName="ActionResponse")]
    public class ActionResponse : global::Microsoft.Dss.Core.IDssSerializable, global::System.ICloneable {
        
        public ActionResponse() {
        }
        
        /// <summary>
        ///Copies the data member values of the current ActionResponse to the specified target object
        ///</summary>
        ///<param name="target">target object (must be an instance of)</param>
        public virtual void CopyTo(Microsoft.Dss.Core.IDssSerializable target) {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse typedTarget = ((global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse)(target));
        }
        
        /// <summary>
        ///Clones ActionResponse
        ///</summary>
        ///<returns>cloned value</returns>
        public virtual object Clone() {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse target0 = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse();
            this.CopyTo(target0);
            return target0;
        }
        
        /// <summary>
        ///Serializes the data member values of the current ActionResponse to the specified writer
        ///</summary>
        ///<param name="writer">the writer to which to serialize</param>
        public virtual void Serialize(System.IO.BinaryWriter writer) {
        }
        
        /// <summary>
        ///Deserializes ActionResponse
        ///</summary>
        ///<param name="reader">the reader from which to deserialize</param>
        ///<returns>deserialized ActionResponse</returns>
        public virtual object Deserialize(System.IO.BinaryReader reader) {
            return this;
        }
    }
    
    [global::Microsoft.Dss.Core.Attributes.DataContractAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html")]
    [global::System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", ElementName="DiagramState")]
    public class DiagramState : global::Microsoft.Dss.Core.IDssSerializable, global::System.ICloneable {
        
        public DiagramState() {
        }
        
        /// <summary>
        ///Copies the data member values of the current DiagramState to the specified target object
        ///</summary>
        ///<param name="target">target object (must be an instance of)</param>
        public virtual void CopyTo(Microsoft.Dss.Core.IDssSerializable target) {
            global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState typedTarget = ((global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState)(target));
        }
        
        /// <summary>
        ///Clones DiagramState
        ///</summary>
        ///<returns>cloned value</returns>
        public virtual object Clone() {
            global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState target0 = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState();
            this.CopyTo(target0);
            return target0;
        }
        
        /// <summary>
        ///Serializes the data member values of the current DiagramState to the specified writer
        ///</summary>
        ///<param name="writer">the writer to which to serialize</param>
        public virtual void Serialize(System.IO.BinaryWriter writer) {
        }
        
        /// <summary>
        ///Deserializes DiagramState
        ///</summary>
        ///<param name="reader">the reader from which to deserialize</param>
        ///<returns>deserialized DiagramState</returns>
        public virtual object Deserialize(System.IO.BinaryReader reader) {
            return this;
        }
    }
    
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Action : global::Microsoft.Dss.ServiceModel.Dssp.Submit<global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest, global:: Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse>> {
        
        public Action() {
        }
        
        public Action(global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body) : 
                base(body) {
        }
        
        public Action(global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body, global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    [global::System.ComponentModel.DescriptionAttribute("Retrieves the current state of the service")]
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Get : global::Microsoft.Dss.ServiceModel.Dssp.Get<global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType, global:: Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState>> {
        
        public Get() {
        }
        
        public Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) : 
                base(body) {
        }
        
        public Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    [global::System.ComponentModel.DescriptionAttribute("Sets the current state of the service.\nThis is raised as an event whenever the st" +
        "ate changes.")]
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Replace : global::Microsoft.Dss.ServiceModel.Dssp.Replace<global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState, global:: Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType>> {
        
        public Replace() {
        }
        
        public Replace(global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body) : 
                base(body) {
        }
        
        public Replace(global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body, global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Subscribe : global::Microsoft.Dss.ServiceModel.Dssp.Subscribe<global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType, global:: Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.SubscribeResponseType>> {
        
        public Subscribe() {
        }
        
        public Subscribe(global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body) : 
                base(body) {
        }
        
        public Subscribe(global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body, global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.SubscribeResponseType> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class DiagramOperations : global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup, global:: Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop, global:: Microsoft.Dss.Core.DsspHttp.HttpGet, global:: Robotics.AutonomusDrive.Diagram.Proxy.Action, global:: Robotics.AutonomusDrive.Diagram.Proxy.Get, global:: Robotics.AutonomusDrive.Diagram.Proxy.Replace, global:: Robotics.AutonomusDrive.Diagram.Proxy.Subscribe> {
        
        public DiagramOperations() {
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.LookupResponse, global::W3C.Soap.Fault> DsspDefaultLookup() {
            global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultLookup(out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.LookupResponse, global::W3C.Soap.Fault> DsspDefaultLookup(global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            }
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultLookup(global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body, out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            }
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType, global::W3C.Soap.Fault> DsspDefaultDrop() {
            global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultDrop(out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType, global::W3C.Soap.Fault> DsspDefaultDrop(global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            }
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultDrop(global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body, out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            }
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.Core.DsspHttp.HttpResponseType, global::W3C.Soap.Fault> HttpGet() {
            global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType body = new global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType();
            global::Microsoft.Dss.Core.DsspHttp.HttpGet operation = new global::Microsoft.Dss.Core.DsspHttp.HttpGet(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice HttpGet(out global::Microsoft.Dss.Core.DsspHttp.HttpGet operation) {
            global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType body = new global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType();
            operation = new global::Microsoft.Dss.Core.DsspHttp.HttpGet(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.Core.DsspHttp.HttpResponseType, global::W3C.Soap.Fault> HttpGet(global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType();
            }
            global::Microsoft.Dss.Core.DsspHttp.HttpGet operation = new global::Microsoft.Dss.Core.DsspHttp.HttpGet(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice HttpGet(global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType body, out global::Microsoft.Dss.Core.DsspHttp.HttpGet operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.Core.DsspHttp.HttpGetRequestType();
            }
            operation = new global::Microsoft.Dss.Core.DsspHttp.HttpGet(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse> Action() {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest();
            global::Robotics.AutonomusDrive.Diagram.Proxy.Action operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Action(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Action(out global::Robotics.AutonomusDrive.Diagram.Proxy.Action operation) {
            global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest();
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Action(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.ActionResponse> Action(global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body) {
            if ((body == null)) {
                body = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest();
            }
            global::Robotics.AutonomusDrive.Diagram.Proxy.Action operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Action(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Action(global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest body, out global::Robotics.AutonomusDrive.Diagram.Proxy.Action operation) {
            if ((body == null)) {
                body = new global::Robotics.AutonomusDrive.Diagram.Proxy.ActionRequest();
            }
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Action(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState> Get() {
            global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            global::Robotics.AutonomusDrive.Diagram.Proxy.Get operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Get(out global::Robotics.AutonomusDrive.Diagram.Proxy.Get operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState> Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            }
            global::Robotics.AutonomusDrive.Diagram.Proxy.Get operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, out global::Robotics.AutonomusDrive.Diagram.Proxy.Get operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            }
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType> Replace() {
            global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState();
            global::Robotics.AutonomusDrive.Diagram.Proxy.Replace operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Replace(out global::Robotics.AutonomusDrive.Diagram.Proxy.Replace operation) {
            global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState();
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType> Replace(global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body) {
            if ((body == null)) {
                body = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState();
            }
            global::Robotics.AutonomusDrive.Diagram.Proxy.Replace operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Replace(global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState body, out global::Robotics.AutonomusDrive.Diagram.Proxy.Replace operation) {
            if ((body == null)) {
                body = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramState();
            }
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.SubscribeResponseType> Subscribe(global::Microsoft.Ccr.Core.IPort notificationPort, params System.Type[] types) {
            global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType();
            global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe(body);
            operation.NotificationPort = notificationPort;
            if ((types != null)) {
                body.TypeFilter = new string[types.Length];
                for (int index = 0; (index < types.Length); index = (index + 1)) {
                    body.TypeFilter[index] = global::Microsoft.Dss.ServiceModel.DsspServiceBase.DsspServiceBase.GetTypeFilterDescription(types[index]);
                }
            }
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Subscribe(global::Microsoft.Ccr.Core.IPort notificationPort, out global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe operation, params System.Type[] types) {
            global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType();
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe(body);
            operation.NotificationPort = notificationPort;
            if ((types != null)) {
                body.TypeFilter = new string[types.Length];
                for (int index = 0; (index < types.Length); index = (index + 1)) {
                    body.TypeFilter[index] = global::Microsoft.Dss.ServiceModel.DsspServiceBase.DsspServiceBase.GetTypeFilterDescription(types[index]);
                }
            }
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<global::Microsoft.Dss.ServiceModel.Dssp.SubscribeResponseType> Subscribe(global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body, global::Microsoft.Ccr.Core.IPort notificationPort, params System.Type[] types) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType();
            }
            global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe(body);
            operation.NotificationPort = notificationPort;
            if ((types != null)) {
                body.TypeFilter = new string[types.Length];
                for (int index = 0; (index < types.Length); index = (index + 1)) {
                    body.TypeFilter[index] = global::Microsoft.Dss.ServiceModel.DsspServiceBase.DsspServiceBase.GetTypeFilterDescription(types[index]);
                }
            }
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Subscribe(global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType body, global::Microsoft.Ccr.Core.IPort notificationPort, out global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe operation, params System.Type[] types) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.SubscribeRequestType();
            }
            operation = new global::Robotics.AutonomusDrive.Diagram.Proxy.Subscribe(body);
            operation.NotificationPort = notificationPort;
            if ((types != null)) {
                body.TypeFilter = new string[types.Length];
                for (int index = 0; (index < types.Length); index = (index + 1)) {
                    body.TypeFilter[index] = global::Microsoft.Dss.ServiceModel.DsspServiceBase.DsspServiceBase.GetTypeFilterDescription(types[index]);
                }
            }
            this.Post(operation);
            return operation.ResponsePort;
        }
    }
    
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    [global::System.ComponentModel.DescriptionAttribute("A user defined activity.")]
    [global::System.ComponentModel.DisplayNameAttribute("AutonomusDrive")]
    public class Contract {
        
        public const string Identifier = "http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html";
        
        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="constructorServicePort">Service constructor port</param>
        /// <param name="service">service path</param>
        /// <param name="partners">the partners of the service instance</param>
        /// <returns>create service response port</returns>
        public static global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> CreateService(global::Microsoft.Dss.Services.Constructor.ConstructorPort constructorServicePort, string service, params Microsoft.Dss.ServiceModel.Dssp.PartnerType[] partners) {
            global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> result = new global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse>();
            global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType serviceInfo = new global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType("http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", service);
            if ((partners != null)) {
                serviceInfo.PartnerList = new System.Collections.Generic.List<Microsoft.Dss.ServiceModel.Dssp.PartnerType>(partners);
            }
            global::Microsoft.Dss.Services.Constructor.Create create = new global::Microsoft.Dss.Services.Constructor.Create(serviceInfo, result);
            constructorServicePort.Post(create);
            return result;
        }
        
        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="constructorServicePort">Service constructor port</param>
        /// <param name="partners">the partners of the service instance</param>
        /// <returns>create service response port</returns>
        public static global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> CreateService(global::Microsoft.Dss.Services.Constructor.ConstructorPort constructorServicePort, params Microsoft.Dss.ServiceModel.Dssp.PartnerType[] partners) {
            global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> result = new global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse>();
            global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType serviceInfo = new global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType("http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", null);
            if ((partners != null)) {
                serviceInfo.PartnerList = new System.Collections.Generic.List<Microsoft.Dss.ServiceModel.Dssp.PartnerType>(partners);
            }
            global::Microsoft.Dss.Services.Constructor.Create create = new global::Microsoft.Dss.Services.Constructor.Create(serviceInfo, result);
            constructorServicePort.Post(create);
            return result;
        }
    }
    
    public class CombinedOperationsPort : global::Microsoft.Dss.Core.DssCombinedOperationsPort {
        
        public CombinedOperationsPort() {
            this.DiagramOperations = new global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramOperations();
            base.Initialize(new global::Microsoft.Dss.Core.DssOperationsPortMetadata(this.DiagramOperations, "http://schemas.tempuri.org/2013/08/autonomusdrive/diagram.html", "DiagramOperations", ""));
        }
        
        public global::Robotics.AutonomusDrive.Diagram.Proxy.DiagramOperations DiagramOperations;
    }
}
