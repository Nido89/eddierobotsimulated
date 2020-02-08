cd C:\Eddie_Robot
title DriveInTriangle
"%~dp0dsshost32" /p:50000 /t:50001 /m:"%~dp0DriveInTriangle\DriveInTriangle.manifest.xml"
/m:"%~dp0DriveInTriangle\irobot.create.simulation (IRobot.Create.Simulation.Manifest).xml"
/d:"%~dp0Eddie_Robot\bin\DriveInTriangle.Y2013.M08.dll"
/d:"%~dp0Eddie_Robot\bin\DriveInTriangle.Y2013.M08.Proxy.dll"
/d:"%~dp0Eddie_Robot\bin\DriveInTriangle.Y2013.M08.Transform.dll"
cmd