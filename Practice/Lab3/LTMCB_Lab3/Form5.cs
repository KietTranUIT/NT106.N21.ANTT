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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        public void InforMessage(string mess)
        {
            ListViewItem item = new ListViewItem();
            item.Text = mess;
            listView1.Items.Add(item);
        }

        public void StartUnsafeThread()
        {
            Socket clientSocket;
            Socket listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            InforMessage("Server running on 127.0.0.1 : 8080");
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            NetworkStream stream = new NetworkStream(clientSocket);
            string content_connect = "New client connect from " + ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)clientSocket.RemoteEndPoint).Port.ToString();
            InforMessage(content_connect);
            int bytesReceived = 0;
            while (clientSocket.Connected && !clientSocket.Poll(0, SelectMode.SelectRead))
            {
                    byte[] recv = new byte[clientSocket.ReceiveBufferSize];
                    string text = "";
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                InforMessage(text);

            }
            listenerSocket.Close();
            clientSocket.Close();
            InforMessage("Close connect!");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}
