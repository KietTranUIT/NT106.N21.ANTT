using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class clientUI : Form
    {
        Socket clientSocket;
        string username;
        int[] numbers = new int[500];
        int index = 0;
        int point = 100;

        public clientUI(Socket clientSocket, string username)
        {
            this.username = username;
            this.clientSocket = clientSocket;
            InitializeComponent();
        }

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

        int time = 3;
        int countPlay = 0;

        void updateForm()
        {
            while(true)
            {
                string data = receiveData(clientSocket);
                string[] datas = data.Split('|');
                if(datas[0] == "0x001")
                {
                    if(username == datas[1])
                    {
                        point = point + 100;
                        textBox5.Invoke(new Action(() =>
                        {
                            textBox5.Text = point.ToString();
                        }));
                    }
                    string[] history = { countPlay.ToString(), datas[1], textBox4.Text + " to " + textBox3.Text };
                    listView1.Invoke(new Action(() =>
                    {
                        ListViewItem value = new ListViewItem(history);
                        listView1.Items.Add(value);
                    }));
                } else if(datas[0] == "0x002")
                {
                    index = 0;
                    countPlay++;
                    textBox2.Invoke(new Action(() =>
                    {
                        textBox2.Text = countPlay.ToString();
                    }));

                    textBox4.Invoke(new Action(() =>
                    {
                        textBox4.Text = datas[1];
                    }));

                    textBox3.Invoke(new Action(() =>
                    {
                        textBox3.Text = datas[2];
                    }));
                } else if(datas[0] == "0x003")
                {
                    // Sau khi kết thúc lưu lịch sử vào file history
                    string filePath = @"C:\Users\FShop\Documents\LTMCB_TH\Lab6\HistoryFile\" + username + ".txt";
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        listView1.Invoke(new Action(() =>
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                string luotChoi = item.SubItems[0].Text;
                                string nguoichienthang = item.SubItems[1].Text;
                                string gioihan = item.SubItems[2].Text;
                                writer.Write(luotChoi + "\t" + nguoichienthang + "\t" + gioihan + "\n");
                            }
                        }));
                        

                    }
                    nameWinner.Invoke(new Action(() =>
                    {
                        nameWinner.Text = datas[1];
                    }));
                    Thread.Sleep(5000);
                    sendData(clientSocket, "0x003|end");
                    clientSocket.Close();
                    break;
                } else if(datas[0] == "0x004")
                {
                    point = point - 1;
                    textBox5.Invoke(new Action(() =>
                    {
                        textBox5.Text = point.ToString();
                    }));
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time == 0)
            {
                label2.Text = "0";
                label2.Visible = false;
                time = 3;
                return;
            }
            label2.Text = time.ToString();
            time--;

        }

        private void Send_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;
            if(number == "")
            {
                MessageBox.Show("Nhập vào một số");
                return;
            }

            sendData(clientSocket, "0x001|" + number);
            textBox1.Text = "";

            label2.Visible = true;
            timer1.Start();
        }

        private void clientUI_Load(object sender, EventArgs e)
        {
            textBox6.Text = username;
            Thread thread = new Thread(new ThreadStart(updateForm));
            thread.Start();
        }

        void playAuto()
        {
            while(nameWinner.Text == "")
            {
                
            loop: Random random = new Random();
                int randomNumber = random.Next(int.Parse(textBox4.Text), int.Parse(textBox3.Text));

                for (int i = 0; i < index; i++)
                {
                    if (randomNumber == numbers[i])
                    {
                        goto loop;
                    }
                }
                numbers[index] = randomNumber;
                index++;

                textBox1.Invoke(new Action(() =>
                {
                    textBox1.Text = randomNumber.ToString();
                }));
                Thread.Sleep(1000);

                sendData(clientSocket, "0x001|" + randomNumber);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(playAuto));
            thread.Start();
        }
    }
}
