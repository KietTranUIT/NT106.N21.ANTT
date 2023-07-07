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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        static readonly List<Socket> clients = new List<Socket>();

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
            int bytesReceived = 0;
            byte[] recv = new byte[1];
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

            while(true)
            {
                Socket handler = listenerSocket.Accept();
                string content_connect = "New client connect from " + ((IPEndPoint)handler.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)handler.RemoteEndPoint).Port.ToString();
                InforMessage(content_connect);
                clients.Add(handler);

                Thread thread = new Thread(() => HandleClient(handler));
                thread.Start();
            }
            listenerSocket.Close();
        }

        private void HandleClient(Socket client)
        {
            try
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                while (true)
                {
                    // Nhận dữ liệu từ client
                    int bytesReceived = client.Receive(buffer);
                    if (bytesReceived > 0)
                    {
                        

                        string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                        ListViewItem item = new ListViewItem();
                        item.Text = message;
                        listView1.Items.Add(item);

                        // Gửi tin nhắn broadcast đến các client khác
                        byte[] broadcastMessage = Encoding.UTF8.GetBytes(message);
                        foreach (Socket c in clients)
                        {
                            if (c != client)
                            {
                                c.Send(broadcastMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: {0}", ex.Message);
            }
            finally
            {
                // Xóa đối tượng Socket khỏi danh sách clients
                clients.Remove(client);

                // Đóng kết nối
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}
