//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Reflection.AssemblyVersionAttribute("0.0.0.0")]
[assembly: global::Microsoft.Dss.Core.Attributes.ServiceDeclarationAttribute(global::Microsoft.Dss.Core.Attributes.DssServiceDeclaration.Transform, SourceAssemblyKey="DriveInTriangle.Y2013.M08, Version=0.0.0.0, Culture=neutral, PublicKeyToken=e3f5c" +
    "a7dcfa79423")]
[assembly: global::System.Security.SecurityTransparentAttribute()]
[assembly: global::System.Security.SecurityRulesAttribute(global::System.Security.SecurityRuleSet.Level1)]

namespace Dss.Transforms.TransformDriveInTriangle {
    
    
    public class Transforms : global::Microsoft.Dss.Core.Transforms.TransformBase {
        
        static Transforms() {
            Register();
        }
        
        public static void Register() {
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_Proxy_DriveRequest_TO_Robotics_DriveInTriangle_DriveOperations_DriveRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.DriveRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_DriveRequest_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_Proxy_DriveResponse_TO_Robotics_DriveInTriangle_DriveOperations_DriveResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.DriveResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_DriveResponse_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_Proxy_RotateRequest_TO_Robotics_DriveInTriangle_DriveOperations_RotateRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.RotateRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_RotateRequest_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_RotateRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_Proxy_RotateResponse_TO_Robotics_DriveInTriangle_DriveOperations_RotateResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.RotateResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_RotateResponse_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_RotateResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveOperationsState), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_Proxy_DriveOperationsState_TO_Robotics_DriveInTriangle_DriveOperations_DriveOperationsState));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.DriveOperations.DriveOperationsState), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_DriveOperations_DriveOperationsState_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveOperationsState));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.Diagram.Proxy.ActionRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_Proxy_ActionRequest_TO_Robotics_DriveInTriangle_Diagram_ActionRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.Diagram.ActionRequest), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_ActionRequest_TO_Robotics_DriveInTriangle_Diagram_Proxy_ActionRequest));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.Diagram.Proxy.ActionResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_Proxy_ActionResponse_TO_Robotics_DriveInTriangle_Diagram_ActionResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.Diagram.ActionResponse), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_ActionResponse_TO_Robotics_DriveInTriangle_Diagram_Proxy_ActionResponse));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::Robotics.DriveInTriangle.Diagram.Proxy.DiagramState), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_Proxy_DiagramState_TO_Robotics_DriveInTriangle_Diagram_DiagramState));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::Robotics.DriveInTriangle.Diagram.DiagramState), new global::Microsoft.Dss.Core.Attributes.Transform(Robotics_DriveInTriangle_Diagram_DiagramState_TO_Robotics_DriveInTriangle_Diagram_Proxy_DiagramState));
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_Proxy_DriveRequest_TO_Robotics_DriveInTriangle_DriveOperations_DriveRequest(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.DriveRequest target = new global::Robotics.DriveInTriangle.DriveOperations.DriveRequest();
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveRequest from = ((global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveRequest)(transformFrom));
            target.Distance = from.Distance;
            target.Power = from.Power;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_DriveRequest_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveRequest(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveRequest target = new global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveRequest();
            global::Robotics.DriveInTriangle.DriveOperations.DriveRequest from = ((global::Robotics.DriveInTriangle.DriveOperations.DriveRequest)(transformFrom));
            target.Distance = from.Distance;
            target.Power = from.Power;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_Proxy_DriveResponse_TO_Robotics_DriveInTriangle_DriveOperations_DriveResponse(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.DriveResponse target = new global::Robotics.DriveInTriangle.DriveOperations.DriveResponse();
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveResponse from = ((global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveResponse)(transformFrom));
            target.Status = from.Status;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_DriveResponse_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveResponse(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveResponse target = new global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveResponse();
            global::Robotics.DriveInTriangle.DriveOperations.DriveResponse from = ((global::Robotics.DriveInTriangle.DriveOperations.DriveResponse)(transformFrom));
            target.Status = from.Status;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_Proxy_RotateRequest_TO_Robotics_DriveInTriangle_DriveOperations_RotateRequest(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.RotateRequest target = new global::Robotics.DriveInTriangle.DriveOperations.RotateRequest();
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateRequest from = ((global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateRequest)(transformFrom));
            target.Degrees = from.Degrees;
            target.Power = from.Power;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_RotateRequest_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_RotateRequest(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateRequest target = new global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateRequest();
            global::Robotics.DriveInTriangle.DriveOperations.RotateRequest from = ((global::Robotics.DriveInTriangle.DriveOperations.RotateRequest)(transformFrom));
            target.Degrees = from.Degrees;
            target.Power = from.Power;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_Proxy_RotateResponse_TO_Robotics_DriveInTriangle_DriveOperations_RotateResponse(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.RotateResponse target = new global::Robotics.DriveInTriangle.DriveOperations.RotateResponse();
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateResponse from = ((global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateResponse)(transformFrom));
            target.Status = from.Status;
            return target;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_RotateResponse_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_RotateResponse(object transformFrom) {
            global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateResponse target = new global::Robotics.DriveInTriangle.DriveOperations.Proxy.RotateResponse();
            global::Robotics.DriveInTriangle.DriveOperations.RotateResponse from = ((global::Robotics.DriveInTriangle.DriveOperations.RotateResponse)(transformFrom));
            target.Status = from.Status;
            return target;
        }
        
        private static global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveOperationsState _cachedInstance0 = new global::Robotics.DriveInTriangle.DriveOperations.Proxy.DriveOperationsState();
        
        private static global::Robotics.DriveInTriangle.DriveOperations.DriveOperationsState _cachedInstance = new global::Robotics.DriveInTriangle.DriveOperations.DriveOperationsState();
        
        public static object Robotics_DriveInTriangle_DriveOperations_Proxy_DriveOperationsState_TO_Robotics_DriveInTriangle_DriveOperations_DriveOperationsState(object transformFrom) {
            return _cachedInstance;
        }
        
        public static object Robotics_DriveInTriangle_DriveOperations_DriveOperationsState_TO_Robotics_DriveInTriangle_DriveOperations_Proxy_DriveOperationsState(object transformFrom) {
            return _cachedInstance0;
        }
        
        private static global::Robotics.DriveInTriangle.Diagram.Proxy.ActionRequest _cachedInstance2 = new global::Robotics.DriveInTriangle.Diagram.Proxy.ActionRequest();
        
        private static global::Robotics.DriveInTriangle.Diagram.ActionRequest _cachedInstance1 = new global::Robotics.DriveInTriangle.Diagram.ActionRequest();
        
        public static object Robotics_DriveInTriangle_Diagram_Proxy_ActionRequest_TO_Robotics_DriveInTriangle_Diagram_ActionRequest(object transformFrom) {
            return _cachedInstance1;
        }
        
        public static object Robotics_DriveInTriangle_Diagram_ActionRequest_TO_Robotics_DriveInTriangle_Diagram_Proxy_ActionRequest(object transformFrom) {
            return _cachedInstance2;
        }
        
        private static global::Robotics.DriveInTriangle.Diagram.Proxy.ActionResponse _cachedInstance4 = new global::Robotics.DriveInTriangle.Diagram.Proxy.ActionResponse();
        
        private static global::Robotics.DriveInTriangle.Diagram.ActionResponse _cachedInstance3 = new global::Robotics.DriveInTriangle.Diagram.ActionResponse();
        
        public static object Robotics_DriveInTriangle_Diagram_Proxy_ActionResponse_TO_Robotics_DriveInTriangle_Diagram_ActionResponse(object transformFrom) {
            return _cachedInstance3;
        }
        
        public static object Robotics_DriveInTriangle_Diagram_ActionResponse_TO_Robotics_DriveInTriangle_Diagram_Proxy_ActionResponse(object transformFrom) {
            return _cachedInstance4;
        }
        
        private static global::Robotics.DriveInTriangle.Diagram.Proxy.DiagramState _cachedInstance6 = new global::Robotics.DriveInTriangle.Diagram.Proxy.DiagramState();
        
        private static global::Robotics.DriveInTriangle.Diagram.DiagramState _cachedInstance5 = new global::Robotics.DriveInTriangle.Diagram.DiagramState();
        
        public static object Robotics_DriveInTriangle_Diagram_Proxy_DiagramState_TO_Robotics_DriveInTriangle_Diagram_DiagramState(object transformFrom) {
            return _cachedInstance5;
        }
        
        public static object Robotics_DriveInTriangle_Diagram_DiagramState_TO_Robotics_DriveInTriangle_Diagram_Proxy_DiagramState(object transformFrom) {
            return _cachedInstance6;
        }
    }
}