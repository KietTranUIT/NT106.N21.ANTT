using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace LTMCB_Lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip_address;
            ip_address = textBox1.Text;
            for(int i=0; i < ip_address.Length; i++)
            {
                if(ip_address[i] == '.')
                {
                    continue;
                }
                if(ip_address[i] < '0' || ip_address[i] > '9' )
                {
                    MessageBox.Show("Nhập sai định dạng Ip address! Xin hãy nhập lại!");
                    textBox1.Text = "";
                    return;
                }
            }
            int port;
            bool success = int.TryParse(textBox2.Text, out port);
            if(!success || port > 65535 || port < 0)
            {
                MessageBox.Show("Port Không hợp lệ! Xin nhập lại!");
                textBox2.Text = "";
                return;
            }
            UdpClient udpClient = new UdpClient();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            udpClient.Send(sendBytes, sendBytes.Length, ip_address, port);
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
