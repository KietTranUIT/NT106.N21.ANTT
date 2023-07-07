using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace ChatClient
{
    public partial class RegistrationForm : Form
    {


        public RegistrationForm()
        {
            InitializeComponent();
            PasswordTbox.UseSystemPasswordChar = true;
            ConfirmPasswordTbox.UseSystemPasswordChar = true;
        }

        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

        string receiveData(Socket clientSocket)
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            return data;
        }

        void sendData(Socket clientSocket, string data)
        {
            byte[] buffer;
            buffer = Encoding.ASCII.GetBytes(data);
            clientSocket.Send(buffer);
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;

            if (UsernameTbox.Text == "")
            {
                label11.Visible = true;
                return;
            }

            if(PasswordTbox.Text == "")
            {
                label12.Visible = true;
                return;

            }

            if (ConfirmPasswordTbox.Text == "")
            {
                label13.Visible = true;
                return;

            }

            if (DisplayNameTbox.Text == "")
            {
                label14.Visible = true;
                return;

            }

            if (EmailTbox.Text == "")
            {
                label15.Visible = true;
                return;

            }

            // Kiểm tra người dùng xác thực đúng mật khẩu hay không
            if (PasswordTbox.Text != ConfirmPasswordTbox.Text)
            {
                //MessageBox.Show("Confirm password not match Password!");
                label8.Visible = true;
                PasswordTbox.Text = "";
                ConfirmPasswordTbox.Text = "";
                return;
            }

            // Tạo một đối tượng Socket
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Tạo một đối tượng User để gửi đến server
            User user = new User()
            {
                Username = UsernameTbox.Text,
                Password = PasswordTbox.Text,
                DisplayName = DisplayNameTbox.Text,
                Email = EmailTbox.Text,
            };

            // Gửi Form đăng kí đến server

            string userData = "0x001|" + JsonConvert.SerializeObject(user);
            sendData(clientSocket, userData);

            // Nhận phản hồi đã đăng kí thành công hay không từ server
            string response = receiveData(clientSocket);
            if (response == "0x001")
            {
                //MessageBox.Show("Register Successfull!");
                label9.Visible = true;
                
            } else if (response == "0x006") {
                //MessageBox.Show("Username exist!");
                label7.Visible = true;
                UsernameTbox.Text = "";
            } else
            {
                //MessageBox.Show("Register Unseccessfull!");
                label10.Visible = true;
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login_form = new LoginForm();
            this.Close();
            login_form.Show();
        }

        int countEyePass = 1;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (countEyePass == 1)
            {
                countEyePass = 0;
                PasswordTbox.UseSystemPasswordChar = false;
            }
            else
            {
                countEyePass = 1;
                PasswordTbox.UseSystemPasswordChar = true;
            }
        }

        int countEyecon = 1;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (countEyecon == 1)
            {
                countEyecon = 0;
                ConfirmPasswordTbox.UseSystemPasswordChar = false;
            }
            else
            {
                countEyecon = 1;
                ConfirmPasswordTbox.UseSystemPasswordChar = true;
            }
        }
    }
}
