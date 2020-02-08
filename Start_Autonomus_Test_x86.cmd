cd C:\Eddie_Robot
title Autonomus_Drive
"bin\Dsshost32.exe" /port:50004 /tcpport:50005 /m:"Autonomus_Drive\AutonomusDrive.manifest.xml"
/m:"Autonomus_Drive\apartment.simulationenginestate (ReferencePlatform2011.Simulation.Manifest).xml"
/m:"Autonomus_Drive\AutonomusDrive.Y2013.M08.Proxy.xml"
/m:"Autonomus_Drive\obstacleavoidancedrive (ReferencePlatform2011.Simulation.Manifest).xml"
/m:"Autonomus_Drive\referenceplatform2011simulation.robotdashboard (ReferencePlatform2011.Simulation.Manifest).xml"
/m:"Autonomus_Drive\referenceplatformrobot (ReferencePlatform2011.Simulation.Manifest).xml"
/m:"Autonomus_Drive\bin\AutonomusDrive.Y2013.M08.Proxy.xml"
/dll:"Autonomus_Drive\bin\AutonomusDrive.Y2013.M08.dll"
/dll:"Autonomus_Drive\bin\AutonomusDrive.Y2013.M08.Proxy.dll"
/dll:"Autonomus_Drive\bin\AutonomusDrive.Y2013.M08.Transform.dll"
cmd