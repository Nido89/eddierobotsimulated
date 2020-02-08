using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Eddie_Control
{
    public partial class frmIP : Form
    {
        private String ip;
        private String ip1;
        private String ip2;
        private String ip3;
        private String ip4;

        public frmIP()
        {
            InitializeComponent();
            label4.Text = readip();
        } 

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ip1 = richTextBox1.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            this.ip2 = richTextBox2.Text;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            this.ip3 = richTextBox3.Text;
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            this.ip4 = richTextBox4.Text;
        }
         
        private void btn_client_Click(object sender, EventArgs e)
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
            System.Diagnostics.Process.Start("Start_Gesture_" + Eddie_Control.Program.processor_architecture+ ".cmd");
        }

        private void btn_server_Click(object sender, EventArgs e)
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
            System.Diagnostics.Process.Start("Start_Gesture_Server_" + Eddie_Control.Program.processor_architecture + ".cmd");
        }
       
        public static String readip()
        {
            
            byte[] address = new byte[4];

            string line;
            string _text;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"Gesture\ipConfig.txt");
            line = file.ReadLine();
            //String Parsen
            char[] delimiterChars = { '.' };
            string[] words = line.Split(delimiterChars);
            file.Close();
            return _text="Current saved IP Adress: " + words[0] + "." +
               words[1] + "." + words[2] +
              "." +words[3] + "\n";
        }

        private void btn_SaveIP_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox2.Text != "" && richTextBox3.Text != "" && richTextBox4.Text != "")
            {
                this.ip = this.ip1 + "." + this.ip2 + "." + this.ip3 + "." + this.ip4;
                StreamWriter writer = new StreamWriter(@"Gesture\ipConfig.txt");
                writer.WriteLine(ip);
                writer.Close();
                label4.Text = readip();
            }
            else
            {
                label4.ForeColor = System.Drawing.Color.Red;
                label4.Text = "Please enter IP values";
            }
        }
    }
}
