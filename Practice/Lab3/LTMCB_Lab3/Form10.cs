using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LTMCB_Lab3
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        TcpClient tcpClient;
        NetworkStream ns;

        private void button2_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
            tcpClient.Connect(ipEndPoint);

            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint localEndPoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
            IPAddress clientIPAddress = localEndPoint.Address;
            string clientIP = clientIPAddress.MapToIPv4().ToString();
            int clientPort = localEndPoint.Port;
            ns = tcpClient.GetStream();
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(clientIP + ":" + clientPort + "_" + textBox1.Text + ": " + textBox2.Text);
            ns.Write(data, 0, data.Length);
            textBox2.Text = "";
        }

        public void StartUnsafeThread()
        {
            int bytesRead = 0;
            NetworkStream stream = tcpClient.GetStream();

            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            while (true)
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ListViewItem item = new ListViewItem();
                    item.Text = message;
                    listView1.Items.Add(item);
                }
            }
        }
    }
}
