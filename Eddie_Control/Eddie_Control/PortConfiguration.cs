using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Eddie_Control
{
    public partial class frmPortConfiguration : Form
    {
        public frmPortConfiguration()
        {
            InitializeComponent();
        }
        private String[] list = new String[] { @"Follow_Me\eddie.serialcomservice (eddie.manifest) (Eddie.Manifest).xml", 
            @"Gesture_Server\eddie.serialcomservice (eddie.manifest) (Eddie.Manifest).xml", 
            @"Sensor\eddie.serialcomservice (eddie.manifest) (eddie.manifest) (Eddie.Manifest).xml", 
            @"Speech Recognition\eddie.serialcomservice (eddie.manifest) (Eddie.Manifest).xml", 
            @"Stop\eddie.serialcomservice (Eddie.Manifest).xml" };
        private String port_number="0";

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            write_to_xml();
            this.Close();
        }
        private void write_to_xml()
        {
            foreach (String _path in list)
            {
                Console.WriteLine(_path);
                StreamWriter writer = new StreamWriter(_path);
                write_Portnumber(writer);
                writer.Close();
            }
        }

        private void write_Portnumber(StreamWriter _writer)
        {   
            _writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _writer.WriteLine("<SerialCOMServiceState xmlns:d=\"http://schemas.microsoft.com/xw/2004/10/dssp.html\" xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsa=\"http://schemas.xmlsoap.org/ws/2004/08/addressing\" xmlns=\"http://www.microsoft.com/2011/07/serialcomservice.html\">");
            _writer.WriteLine("\t<PortNumber>" + this.port_number + "</PortNumber>");
            _writer.WriteLine("\t<BaudRate>115200</BaudRate>");
            _writer.WriteLine("\t<Parity>None</Parity>");
            _writer.WriteLine("\t<DataBits>8</DataBits>");
	        _writer.WriteLine("\t<StopBits>One</StopBits>");
	        _writer.WriteLine("\t<ReadTimeout>200</ReadTimeout>");
	        _writer.WriteLine("\t<WriteTimeout>200</WriteTimeout>");
	        _writer.WriteLine("\t<Handshake>None</Handshake>");
	        _writer.WriteLine("\t<RtsEnable>false</RtsEnable>");
	        _writer.WriteLine("\t<DtrEnable>false</DtrEnable>");
	        _writer.WriteLine("\t<DiscardNull>false</DiscardNull>");
	        _writer.WriteLine("\t<Asynchronous>true</Asynchronous>");
	        _writer.WriteLine("\t<AutoConnect>true</AutoConnect>");
	        _writer.WriteLine("\t<IsConnected>false</IsConnected>");
            _writer.WriteLine("</SerialCOMServiceState>");
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.port_number = numUpDown.Value.ToString();
        }
    }
}
