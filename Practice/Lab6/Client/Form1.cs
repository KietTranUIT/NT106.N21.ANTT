using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Thiết lập địa chỉ Ip và Port để kết nối đến server
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

        // Gửi dữ liệu thông qua socket
        string receiveData(Socket clientSocket)
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            return data;
        }

        // Nhận dữ liệu thông qua socket
        void sendData(Socket clientSocket, string data)
        {
            byte[] buffer;
            buffer = Encoding.ASCII.GetBytes(data);
            clientSocket.Send(buffer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTbox.Text;

            // Kiểm tra xem người dùng đã nhập vào usrername chưa
            if(username == "")
            {
                MessageBox.Show("Chưa điền username!");
                return;
            }

            // Tạo một đối tượng Socket
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Gửi thông tin username đến server
            sendData(clientSocket, "0x000|" + username);

            // Nhận thông tin phản hồi đã lưu username từ Server
            string response = receiveData(clientSocket);
            if(response != "0x000|Success")
            {
                MessageBox.Show("Kết nối thất bại");
                clientSocket.Close();
                return;
            }

            // Mở form UI chính của client
            clientUI client = new clientUI(clientSocket, username);
            client.Show();
            this.Hide();

        }
    }
}
