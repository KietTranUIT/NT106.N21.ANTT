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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int port;
        UdpClient udpServer;
        IPEndPoint RemotelpEndPoint;

        public void InforMessage(string mess)
        {
            ListViewItem item = new ListViewItem();
            item.Text = mess;
            listView1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = int.TryParse(textBox1.Text, out port);
            if (!success || port > 65535 || port < 0)
            {
                MessageBox.Show("Port không hợp lệ! Vui lòng nhập lại!");
                textBox1.Text = "";
                return;
            }

            InforMessage("Server Started...!");

            Control.CheckForIllegalCrossThreadCalls = false;
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }

        public void serverThread()
        {
            udpServer = new UdpClient(port);
            RemotelpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                Byte[] receiveBytes = udpServer.Receive(ref RemotelpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string mess = RemotelpEndPoint.Address.ToString() + ":" + returnData.ToString();

                InforMessage(mess);
            }

        }



        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
