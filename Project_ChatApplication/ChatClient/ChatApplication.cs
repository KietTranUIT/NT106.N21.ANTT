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
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;

namespace ChatClient
{
    public partial class ChatApplication : Form
    {
        private Socket clientSocket;
        private string username;
        private string display_name;
        private Dictionary<string, string> users = new Dictionary<string, string>();
        public ChatApplication(Socket clientSocket, string username, string display_name)
        {
            InitializeComponent();
            this.clientSocket = clientSocket;
            this.username = username;
            DisplayName.Text = display_name;
            this.display_name = display_name;
        }

        string receiveData(Socket clientSocket)
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
            return data;
        }

        void sendData(Socket clientSocket, string data)
        {
            byte[] buffer;
            buffer = Encoding.UTF8.GetBytes(data);
            clientSocket.Send(buffer);
        }

        void sendImage(Socket clientSocket, Image image)
        {
            var ms = new MemoryStream();
            Bitmap bmp = new Bitmap(image);
            bmp.Save(ms, ImageFormat.Png);
            byte[] buffer = ms.ToArray();
            clientSocket.Send(buffer);
        }

        string findDisplayName(string username)
        {
            foreach(KeyValuePair<string, string> user in users)
            {
                if(user.Key == username)
                {
                    return user.Value;
                }
            }
            return "";
        }

        Image receiveImage(Socket clientSocket)
        {
            Image image;
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public void updateChatApp()
        {
            while (true)
            {
                string data = receiveData(clientSocket);
                string[] input = data.Split('|');
                if (input[0] == "0x005")
                {
                    string[] datanew = input[1].Split(',');
                    int lendata = datanew.Length;
                    for(int i = 0; i < lendata; i++)
                    {
                        if(datanew[i] == "")
                        {
                            continue;
                        }
                        string[] text = datanew[i].Split('/');
                        users.Add(text[0], text[1]);
                        listUser.Invoke(new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(text[1]);
                            listUser.Items.Add(item);
                        }));
                        toUser.Invoke(new Action(() =>
                        {
                            toUser.Items.Add(text[1]);
                        }));
                    }
                    
                }
                else if (input[0] == "0x008")
                {
                    Message mess = JsonConvert.DeserializeObject<Message>(input[1]);
                    ChatRoom.Invoke(new Action(() =>
                    {
                        if(mess.Receiver == "public")
                        {
                            string name = findDisplayName(mess.Sender);
                            
                            ChatRoom.AppendText("\n[Public] from " + name + ": " + mess.Text);
                            ChatRoom.AppendText("\n" + mess.DateSend);
                        } else
                        {
                            string name = findDisplayName(mess.Sender);
                            ChatRoom.AppendText("\n[Private] from " + name + ": " + mess.Text);
                            ChatRoom.AppendText("\n" + mess.DateSend);
                        }

                    }));
                }
                else if (input[0] == "0x009")
                {
                    string[] datanew = input[1].Split('/');
                    listUser.Invoke(new Action(() =>
                    {
                        ListViewItem item = listUser.FindItemWithText(datanew[1]);
                        listUser.Items.Remove(item);
                    }));
                    toUser.Invoke(new Action(() =>
                    {
                        int index = toUser.FindString(datanew[1]);
                        toUser.Items.RemoveAt(index);
                    }));
                    users.Remove(datanew[0]);
                }
                else if (input[0] == "0x010")
                {
                    clientSocket.Close();
                    return;
                } else if(input[0] == "0x011")
                {
                    string[] dt = input[1].Split(',');
                    Image image = receiveImage(clientSocket);
                    
                    ChatRoom.Invoke(new Action(() =>
                    {
                        if(dt[1] == "public")
                        {
                            Clipboard.SetImage(image);
                            ChatRoom.AppendText("\n[Public] from " + dt[0] + ": ");
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + dt[2]);

                        } else
                        {
                            Clipboard.SetImage(image);
                            ChatRoom.AppendText("\n[Private] from " + dt[1] + ": ");
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + dt[2]);
                        }

                    }));
                } else if(input[0] == "0x012")
                {
                    string[] dt = input[1].Split(',');

                    byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                    string filepath = "C:\\Users\\FShop\\Documents\\FileChatApp\\" + dt[2];
                    using (FileStream stream = new FileStream(filepath, FileMode.Create))
                    {
                        int bytesRead = 0;
                        //do
                        //{
                            bytesRead = clientSocket.Receive(buffer);
                            stream.Write(buffer, 0, bytesRead);
                        //}
                        //while (bytesRead > 0);
                    }
                    if(dt[3] == "public")
                    {
                        ChatRoom.Invoke(new Action(() =>
                        {
                            ChatRoom.AppendText("\n[Public] from " + dt[0] + ": receive file (" + dt[2] + ")");
                            ChatRoom.AppendText("\n" + dt[1]);
                        }));
                    } else
                    {
                        ChatRoom.Invoke(new Action(() =>
                        {
                            ChatRoom.AppendText("\n[Private] from " + dt[0] + ": receiver file(" + dt[2] + ")");
                            ChatRoom.AppendText("\n" + dt[1]);
                        }));
                    }
                    
                    
                } else if(input[0] == "0x014")
                {
                    Message[] messes = new Message[input.Length - 1];
                    int index = 0;
                    for(int i = 1; i < input.Length; i++)
                    {
                        messes[index] = JsonConvert.DeserializeObject<Message>(input[i]);
                        index++;
                    }
                    
                    listHistory.Invoke(new Action(() =>
                    {
                        for (int i = 0; i < messes.Length; i++)
                        {
                            string[] value = { messes[i].Sender, messes[i].Receiver, messes[i].Text, messes[i].DateSend };
                            ListViewItem item = new ListViewItem(value);
                            listHistory.Items.Add(item);
                        }
                    }));
                } else if(input[0] == "0x015")
                {
                    User user = JsonConvert.DeserializeObject<User>(input[1]);
                    textBox1.Invoke(new Action(() =>
                    {
                        textBox1.Text = user.Username;
                    }
                    ));
                    textBox2.Invoke(new Action(() =>
                    {
                        textBox2.Text = user.Password;
                    }
                    ));
                    textBox3.Invoke(new Action(() =>
                    {
                        textBox3.Text = user.DisplayName;
                    }
                    ));
                    textBox4.Invoke(new Action(() =>
                    {
                        textBox4.Text = user.Email;
                    }
                    ));
                    panel2.Invoke(new Action(() =>
                    {
                        panel2.Visible = true;
                    }
                    ));
                }
            }
        }

        private void ChatApplication_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(updateChatApp));
            thread.Start();
        }

        

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;

            if (ls.SelectedItems.Count > 0)
            {
                ListViewItem item_selected = ls.SelectedItems[0];
                string selected = item_selected.Text;
                
                NameDisplay.Text = selected;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string receiver = "public";
        int check = 0;

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string data = MessageBox.Text;
            if(data == "" || receiver == "")
            {
                return;
            }

            if(checkPrivate.Checked == false && checkPublic.Checked == false)
            {
                System.Windows.Forms.MessageBox.Show("chon Mode!");
                return;
            }

            if (checkPrivate.Checked == true)
            {
                if(check == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                    return;
                }
                string usrname_receiver = "";
                foreach (KeyValuePair<string, string> user in users)
                {
                    if (user.Value == receiver)
                    {
                        usrname_receiver = user.Key;
                        break;
                    }
                }

                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                Message mess = new Message()
                {
                    Sender = username,
                    Receiver = usrname_receiver,
                    DateSend = date,
                    Text = data
                };

                int currentPosition = ChatRoom.SelectionStart;
                string text = "\n[Private] to "+ receiver + ": " + mess.Text + "\n" + mess.DateSend;
                int selectionLength = text.Length;
                ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                ChatRoom.SelectedText = text;
                ChatRoom.SelectionColor = Color.White;

                string messData = "0x007|" + JsonConvert.SerializeObject(mess);
                sendData(clientSocket, messData);
            } else if(checkPublic.Checked == true)
            {
                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                Message mess = new Message()
                {
                    Sender = username,
                    Receiver = "public",
                    DateSend = date,
                    Text = data
                };

                int currentPosition = ChatRoom.SelectionStart;
                string text = "\n[Public] to all user: " + mess.Text + "\n" + mess.DateSend;
                int selectionLength = text.Length;
                ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                ChatRoom.SelectedText = text;
                ChatRoom.SelectionColor = Color.White;

                string messData = "0x007|" + JsonConvert.SerializeObject(mess);
                sendData(clientSocket, messData);
            }
            MessageBox.Text = "";
        }


        private void toUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox ls = sender as ListBox;
            if(ls.SelectedIndex != -1)
            {
                check = 1;
                string test = ls.SelectedItem.ToString();
                System.Windows.Forms.MessageBox.Show(test);
                receiver = test;
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            sendData(clientSocket, "0x009|" + username + "/" + display_name);
            LoginForm login = new LoginForm();
            login.Show();
            this.Dispose();

        }

        int count = 0;

        private void buttonEmoji_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count = 1;
                listEmoji.Show();
            }
            else
            {
                count = 0;
                listEmoji.Hide();
            }
        }

        private void listEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;

            if (ls.SelectedItems.Count > 0)
            {
                int imageKey = ls.SelectedItems[0].ImageIndex;
                Image image = ls.LargeImageList.Images[imageKey];

                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                if (checkPublic.Checked == true)
                {
                    int currentPosition = ChatRoom.SelectionStart;
                    string text = "\n[Public] to all user: ";
                    int selectionLength = text.Length;
                    ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                    ChatRoom.SelectedText = text;
                    //ChatRoom.AppendText("\n[Public] to all user: ");
                    Clipboard.SetImage(image);
                    ChatRoom.Paste();
                    ChatRoom.AppendText("\n" + date);
                    ChatRoom.SelectionColor = Color.White;
                    sendData(clientSocket, "0x011|public," + date);
                    Thread.Sleep(1000);
                } else if(checkPrivate.Checked == true)
                {
                    if(check == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                        return;
                    }
                    
                    foreach (KeyValuePair<string, string> ct in users)
                    {
                        if(ct.Value == receiver)
                        {
                            int currentPosition = ChatRoom.SelectionStart;
                            string text = "\n[Private] to " + receiver + ": ";
                            int selectionLength = text.Length;
                            ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                            ChatRoom.SelectedText = text;
                            //ChatRoom.AppendText("\n[Private] to " + receiver + ": ");
                            Clipboard.SetImage(image);
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + date);
                            ChatRoom.SelectionColor = Color.White;
                            sendData(clientSocket, "0x011|" + ct.Key + "," + ct.Value + "," + date);
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                sendImage(clientSocket, image);
                listEmoji.Hide();
                count = 0;
                ls.SelectedItems.Clear();
            }
        }

        public void sendImage(Image image)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("dd/MM/yyyy HH:mm:ss");

            if (checkPublic.Checked == true)
            {
                ChatRoom.AppendText("\n[Public] to all user: ");
                Clipboard.SetImage(image);
                ChatRoom.Paste();
                ChatRoom.AppendText("\n" + date);
                sendData(clientSocket, "0x011|public," + date);
                Thread.Sleep(1000);
            }
            else if (checkPrivate.Checked == true)
            {
                if (check == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                    return;
                }

                foreach (KeyValuePair<string, string> ct in users)
                {
                    if (ct.Value == receiver)
                    {
                        ChatRoom.AppendText("\n[Private] to " + receiver + ": ");
                        Clipboard.SetImage(image);
                        ChatRoom.Paste();
                        ChatRoom.AppendText("\n" + date);
                        sendData(clientSocket, "0x011|" + ct.Key + "," + ct.Value + "," + date);
                        break;
                    }
                }
                Thread.Sleep(1000);
            }
            sendImage(clientSocket, image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho OpenFileDialog
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Lấy danh sách các tệp đang được chọn
            string[] selectedFiles = { "0" };

            // Mở hộp thoại chọn tệp và xử lý kết quả
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFiles = openFileDialog.FileNames;
            } else
            {
                return;
            }

            foreach(string file in selectedFiles) {
                string[] name_file = file.Split("\\");
                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                if (checkPublic.Checked == true)
                {
                    sendData(clientSocket, "0x012|public," + date + "," + name_file[name_file.Length - 1]);
                    Thread.Sleep(1000);
                }
                else if (checkPrivate.Checked == true)
                {
                    if (check == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                        return;
                    }
                    foreach (KeyValuePair<string, string> ct in users)
                    {
                        if (ct.Value == receiver)
                        {
                            sendData(clientSocket, "0x012|" + ct.Key + "," + ct.Value + "," + date + "," + name_file[name_file.Length - 1]);
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                byte[] fileData = File.ReadAllBytes(file);
                clientSocket.Send(fileData);
                if(checkPublic.Checked == true)
                {
                    int currentPosition = ChatRoom.SelectionStart;
                    string text = "\n[Public] to all user: you sent file " + name_file[name_file.Length - 1] + "\n" + now;
                    int selectionLength = text.Length;
                    ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                    ChatRoom.SelectedText = text;
                    ChatRoom.SelectionColor = Color.White;
                } else
                {
                    int currentPosition = ChatRoom.SelectionStart;
                    string text = "\n[Private] to " + receiver + ": you sent file" + name_file[name_file.Length - 1] + "\n" + now;
                    int selectionLength = text.Length;
                    ChatRoom.SelectionColor = Color.FromArgb(0, 255, 255);
                    ChatRoom.SelectedText = text;
                    ChatRoom.SelectionColor = Color.White;
                    //ChatRoom.AppendText("\n[Private] to " + receiver + ": you sent file" + name_file[name_file.Length - 1]);
                }
                
            }
        }

        int count1 = 0;
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            if(count1 == 0)
            {
                changePassword.Visible = true;
                historyMessage.Visible = true;

                count1 = 1;
            } else
            {
                changePassword.Visible = false;
                historyMessage.Visible = false;

                count1 = 0;

            }
        }

        int countHistory = 0;

        private void listSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;
            if (ls.SelectedItems.Count > 0)
            {
                string option = ls.SelectedItems[0].Text;
                if(option == "Change password")
                {
                    if (countSetting == 0)
                    {
                        countSetting = 1;
                        panelResetPassword.Show();
                    } else
                    {
                        countSetting = 0;
                        panelResetPassword.Hide();
                        return;
                    }
                    ls.SelectedItems.Clear();
                } else
                {
                    if(countHistory == 0)
                    {
                        countHistory = 1;
                        panelHistory.Show();
                        sendData(clientSocket, "0x014|" + username);
                    } else
                    {
                        countHistory = 0;
                        panelHistory.Hide();
                        return;
                    }
                    ls.SelectedItems.Clear();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            string new_password = textNewPassword.Text;
            if(new_password == "")
            {
                label7.Visible = true;
                return;
            }

            sendData(clientSocket, "0x013|" + username + "/" + new_password);
            label6.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int countSetting = 0;
        private void changePassword_Click(object sender, EventArgs e)
        {
            if (countSetting == 0)
            {
                countSetting = 1;
                panelResetPassword.Show();
            }
            else
            {
                countSetting = 0;
                panelResetPassword.Hide();
                return;
            }
        }

        private void historyMessage_Click(object sender, EventArgs e)
        {
            if (countHistory == 0)
            {
                countHistory = 1;
                panelHistory.Show();
                sendData(clientSocket, "0x014|" + username);
            }
            else
            {
                countHistory = 0;
                panelHistory.Hide();
                return;
            }
        }

        int countdis = 0;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(countdis == 0)
            {
                sendData(clientSocket, "0x015|" + username);
                countdis = 1;
            } else
            {
                panel2.Visible = false;
                countdis = 0;
            }
        }
    }
}
