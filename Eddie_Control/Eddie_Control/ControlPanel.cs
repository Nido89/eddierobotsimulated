using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Eddie_Control
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }        
           
        private void startform()
        {
            frmIP _form = new frmIP();
            _form.ShowDialog();
            //Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form_ip());
        }
        private void configport()
        {
            frmPortConfiguration _form_config = new frmPortConfiguration();
            _form_config.ShowDialog(); 
        }

        private void btnAutonomusTestDrive_Click(object sender, EventArgs e)
        {
            Process[] close = Process.GetProcessesByName("cmd");
            foreach (Process p in close)
            {
                if (p.MainWindowTitle == "Speech_Recognition" || p.MainWindowTitle == "Sensor" || p.MainWindowTitle == "Gesture_Client" || p.MainWindowTitle == "Gesture_Server" || p.MainWindowTitle == "Follow_Me" || p.MainWindowTitle == "Stop")
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }

            //System.Diagnostics.Process.Start("Start_Autonomus_Test_" + Eddie_Control.Program.processor_architecture + ".cmd");
            System.Diagnostics.Process.Start("Start_DriveInTriangle_" + Eddie_Control.Program.processor_architecture + ".cmd");
        }

        private void btnFindHumans_Click(object sender, EventArgs e)
        {
            Process[] close = Process.GetProcessesByName("cmd");
            foreach (Process p in close)
            {
                if (p.MainWindowTitle == "Speech_Recognition" || p.MainWindowTitle == "Sensor" || p.MainWindowTitle == "Gesture_Client" || p.MainWindowTitle == "Gesture_Server" || p.MainWindowTitle == "Follow_Me" || p.MainWindowTitle == "Stop")
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }
            System.Diagnostics.Process.Start("Start_Sensor_" + Eddie_Control.Program.processor_architecture + ".cmd");
        }

        private void btnFindObjects_Click(object sender, EventArgs e)
        {
            Thread _thread = new Thread(new ThreadStart(startform));
            _thread.Start();
        }

        private void btnVoiceDrive_Click(object sender, EventArgs e)
        {
            Process[] close = Process.GetProcessesByName("cmd");
            foreach (Process p in close)
            {
                if (p.MainWindowTitle == "Speech_Recognition" || p.MainWindowTitle == "Sensor" || p.MainWindowTitle == "Gesture_Client" || p.MainWindowTitle == "Gesture_Server" || p.MainWindowTitle == "Follow_Me" || p.MainWindowTitle == "Stop")
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }
            System.Diagnostics.Process.Start("Start_Speech_Recognition_" + Eddie_Control.Program.processor_architecture + ".cmd");
        }

        private void btnConfigurePort_Click(object sender, EventArgs e)
        {
            Thread _thread = new Thread(new ThreadStart(configport));
            _thread.Start();
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            Process[] close = Process.GetProcessesByName("cmd");
            foreach (Process p in close)
            {
                if (p.MainWindowTitle == "Speech_Recognition" || p.MainWindowTitle == "Sensor" || p.MainWindowTitle == "Gesture_Client" || p.MainWindowTitle == "Gesture_Server" || p.MainWindowTitle == "Follow_Me" || p.MainWindowTitle == "Stop")
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }
            System.Diagnostics.Process.Start("Stop_" + Eddie_Control.Program.processor_architecture + ".cmd");
        } 

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    Process[] close = Process.GetProcessesByName("cmd");
        //    foreach (Process p in close)
        //    {
        //        if (p.MainWindowTitle == "Speech_Recognition" || p.MainWindowTitle == "Sensor" || p.MainWindowTitle == "Gesture_Client" || p.MainWindowTitle == "Gesture_Server" || p.MainWindowTitle == "Follow_Me" || p.MainWindowTitle == "Stop")
        //        {
        //            p.CloseMainWindow();
        //            p.Close();
        //        }
        //    }
        //    System.Diagnostics.Process.Start("Stop_" + Eddie_Control.Program.processor_architecture + ".cmd");
        //}  
    }
}
