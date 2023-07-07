using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
//using System.Net.Sockets.TcpClient;

namespace LTMCB_Lab3
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        TcpClient tcpClient;
        NetworkStream ns;


        private void button1_Click(object sender, EventArgs e)
        {
            ns = tcpClient.GetStream();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello server\n");
            ns.Write(data, 0, data.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
            tcpClient.Connect(ipEndPoint);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Byte[] data = System.Text.Encoding.ASCII.GetBytes("quit\n");
            //ns.Write(data, 0, data.Length);
            ns.Close();
            tcpClient.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            this.Close();
            //form1.Show();
        }
    }
}
