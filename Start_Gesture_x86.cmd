cd C:\Parallax_Eddie
title Gesture_Client
"bin\Dsshost32.exe" /port:50004 /tcpport:50005 /m:"Gesture\gesture.manifest.xml"
/m:"Gesture\kinect (Kinect.Manifest).xml"
/dll:"bin\Gesture.Y2012.M12.dll"
/dll:"bin\Gesture.Y2012.M12.Proxy.dll"
/dll:"bin\Gesture.Y2012.M12.Transform.dll"
cmd