using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Tạo một map để lưu trữ tất cả client đang kết nối với server
        static Dictionary<string, Socket> clientSockets = new Dictionary<string, Socket>();
        static Dictionary<string, int> count_winner = new Dictionary<string, int>();
        static Dictionary<string, int> count_option = new Dictionary<string, int>();


        int countUser = 0;
        int countPlay = 1;
        int winner = 0;
        int login = 0;

        // Thiết lập địa chỉ Ip và Port
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

        // Nhận dữ liệu từ client
        static string receiveData(Socket handler)
        {
            byte[] buffer = new byte[handler.ReceiveBufferSize];
            int bytesReceived = handler.Receive(buffer);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
            return data;
        }

        // Gửi dữ liệu đến client
        static void sendData(Socket handler, string data)
        {
            byte[] buffer;
            buffer = Encoding.UTF8.GetBytes(data);
            handler.Send(buffer);
        }

        void randomRange()
        {
            Random random = new Random();
            loop:  int n1 = random.Next(0, 500);
            int n2 = random.Next(0, 500);
            if(n1 < n2)
            {
                textBox1.Text = n1.ToString();
                textBox2.Text = n2.ToString();
            } else if(n1 > n2)
            {
                textBox1.Text = n2.ToString();
                textBox2.Text = n1.ToString();
            } else
            {
                goto loop;
            }
        }

        void StartServer()
        {
            

            numberUser.Text = countUser.ToString();

            // Tạo đối tượng socket để lắng nghe
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(ipAddress, port));
            listener.Listen(-1);
            Console.WriteLine("Server is running!");

            // Chấp nhận các kết nối từ phía client
            while (true)
            {
                Socket handler = listener.Accept();

                // Cập nhật lại số lượng user
                countUser++;
                numberUser.Text = countUser.ToString();

                Thread thread = new Thread(() => handlerClient(ref handler));
                thread.Start();
            }
        }

        string url = "https://ctxt.io";

        private async void SendData(string url, string data)
        {
            try
            {
                using (var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded"))
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.PostAsync(url, content);
                        var responseString = await response.Content.ReadAsStringAsync();
                        
                    }
                }
                MessageBox.Show("Thành công gửi toàn bộ lịch sử trò chơi lên website https://ctxt.io");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        void endGame()
        {
            string data = "";
            foreach (ListViewItem item in listView1.Items)
            {
                string luotChoi = item.SubItems[0].Text;
                string nguoichienthang = item.SubItems[1].Text;
                string socantim = item.SubItems[2].Text;
                string gioihan = item.SubItems[3].Text;
                data += luotChoi + "\t" + nguoichienthang + "\t" + socantim + "\t" + gioihan + "\n";
            }
            SendData(url, data);
            int count = 0;
            string user_winner = "";
            int max = 0;
            foreach(KeyValuePair<string, int> i in count_winner)
            {
                count++;
                if(count == 1)
                {
                    user_winner = i.Key;
                    max = i.Value;
                    continue;
                }
                if(i.Value > max)
                {
                    user_winner = i.Key;
                    max = i.Value;
                } else if(i.Value == max)
                {
                    if(count_option[i.Key] < count_option[user_winner])
                    {
                        user_winner = i.Key;
                        max = i.Value;
                    }
                }
            }
            textBox5.Text = user_winner;
            foreach (KeyValuePair<string, Socket> user in clientSockets)
            {
                 sendData(user.Value, "0x003|" + user_winner);
            }
        }

        void handWinner(string name_winner)
        {
            string[] history = { countPlay.ToString(), name_winner, numberFind.Text, textBox1.Text + " to " + textBox2.Text };
            ListViewItem value = new ListViewItem(history);
            listView1.Items.Add(value);

            count_winner[name_winner] += 1;
            

            foreach(KeyValuePair<string, Socket> user in clientSockets)
            {
                sendData(user.Value, "0x001|" + name_winner);
            }

            countPlay++;
            if(countPlay == 6)
            {
                endGame();
            }
            textBox4.Text = countPlay.ToString();
            playGame();
            winner = 0;
        }

        void handlerClient(ref Socket handler)
        {
            string username = "";
            while (true)
            {
                if(winner > 0)
                {
                    continue;
                }
                if(login == 1)
                {
                    sendData(handler, "0x002|" + textBox1.Text + "|" + textBox2.Text);
                    login = 2;
                }
                // Thêm thêm user vào mảng
                string data = receiveData(handler);
                string[] datas = data.Split('|');

                if (datas[0] == "0x000")
                {
                    username = datas[1];
                    clientSockets.Add(datas[1], handler);
                    count_winner.Add(datas[1], 0);
                    count_option.Add(datas[1], 0);
                    sendData(handler, "0x000|Success");
                    login = 1;
                } else if(datas[0] == "0x001")
                {
                    count_option[username] += 1;
                    if (datas[1] == numberFind.Text)
                    {
                        winner++;
                        if (winner == 1)
                        {
                            handWinner(username);
                        }
                    } else
                    {
                        sendData(handler, "0x004|wrong");
                    }
                } else if(datas[0] == "0x003")
                {
                    break;
                }
            }
            handler.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playGame();
            textBox4.Text = countPlay.ToString();
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();
        }

        void playGame()
        {
            if(countPlay <= 5)
            {
                randomRange();
                foreach(KeyValuePair<string, Socket> user in clientSockets)
                {
                    sendData(user.Value, "0x002|" + textBox1.Text + "|" + textBox2.Text);
                }

                Random random = new Random();
                int randomNumber = random.Next(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                numberFind.Text = randomNumber.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
