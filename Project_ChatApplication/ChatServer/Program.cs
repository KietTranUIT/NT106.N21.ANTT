using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Collections.Generic;
using Firebase.Storage;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            startServer();
        }

        // Tạo một map để lưu trữ tất cả client đang kết nối với server (đã được server xác thực)
        static Dictionary<string, Socket> clientSockets = new Dictionary<string, Socket>();

        static string receiveData(Socket handler)
        {
            byte[] buffer = new byte[handler.ReceiveBufferSize];
            int bytesReceived = handler.Receive(buffer);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
            return data;
        }

        static void sendData(Socket handler, string data)
        {
            byte[] buffer;
            buffer = Encoding.UTF8.GetBytes(data);
            handler.Send(buffer);
        }

        static void Broadcast(string display_name)
        {
            foreach(KeyValuePair<string, Socket> client in clientSockets)
            {
                sendData(client.Value,"0x005|" + display_name);
            }
        }

        // Khởi động server
        static void startServer()
        {
            // Cấu hình để kết nối với realtime database Firebase
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "OW9ry0nAgG5IqWqpFPU3e37W6Z75C9i3IdDy5QZ7",
                BasePath = "https://chatapplication-95820-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);

            // Tạo đối tượng socket để lắng nghe
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Thiết lập địa chỉ Ip và Port
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8181;

            listener.Bind(new IPEndPoint(ipAddress, port));
            listener.Listen(-1);
            Console.WriteLine("Server is running!");

            // Chấp nhận các kết nối từ phía client
            while(true)
            {
                Socket handler = listener.Accept();
                
                Console.Write("New Client Conncect!");


                Thread thread = new Thread(() => handlerClientAsync(ref handler, client));
                thread.Start();
            }
        }

        static bool handlerLogin(Socket handler, IFirebaseClient client, string form_login)
        {
            string username = "", password = "";

            // Tách Username, Password trong form login
            string[] strs = form_login.Split('/');
            foreach (string str in strs)
            {
                string[] strSplit = str.Split('=');
                if (str[0] == 'U')
                {
                    username = strSplit[1];
                }
                else
                {
                    password = strSplit[1];
                }
            }

            // Truy vấn Username trên database
            FirebaseResponse res = client.Get(@"Users/" + username);
            User user = res.ResultAs<User>();

            // Kiểm tra có user hay không
            if (user == null)
            {
                sendData(handler, "0x003");
                return false;
            }

            // Kiểm tra username và password
            if(user.Username == username)
            {
                if(password == user.Password)
                {
                    sendData(handler, "0x000" + user.DisplayName);
                    // gửi tín hiệu kết nối của user tới tất cả các user khác đang kết nối với server
                    Broadcast(user.Username + "/" + user.DisplayName);

                    string bcast = "0x005|";
                    if(clientSockets.Count == 0)
                    {
                        clientSockets.Add(user.Username + "/" + user.DisplayName, handler);
                        return true;
                    }

                    // gửi tín hiệu kết nối của các user đang kết nối tới user vừa kết nối
                    foreach(KeyValuePair<string, Socket> client_user in clientSockets)
                    {
                        bcast = bcast + client_user.Key + ",";
                        //sendData(handler, "0x005|" + client_user.Key);
                        //Thread.Sleep(3000);
                    }
                    sendData(handler, bcast);

                    // thêm user vào danh sách
                    clientSockets.Add(user.Username + "/" + user.DisplayName , handler);
                    return true;
                } else
                {
                        sendData(handler, "0x004");
                }
            }
            sendData(handler, "0x003");
            return false;
        }

        static void handlerRegister(Socket handler, IFirebaseClient client, string register_form)
        {
            // Thiết lập id nhận diện cho User
            DateTime now = DateTime.Now;
            string id = now.Second.ToString() + now.Minute.ToString() + now.Hour.ToString() + now.Day.ToString() + now.Month.ToString() + now.Year.ToString();
            // Chuyển user dạng string thành một đối tượng
            User user = JsonConvert.DeserializeObject<User>(register_form);

            FirebaseResponse res = client.Get(@"Users/" + user.Username);
            User userget = res.ResultAs<User>();
            if(userget != null)
            {
                sendData(handler, "0x006");
                return;
            }

            // Đẩy dữ liệu lên firebase
            user.Id = id;
            SetResponse set = client.Set(@"Users/" + user.Username, user);

            // Phản hồi tín hiệu đăng kí thành công
            sendData(handler, "0x001");
        }

        static void handlerMessage(Socket handler, IFirebaseClient cl, string data)
        {
            Message mess = JsonConvert.DeserializeObject<Message>(data);
            string id_mess = mess.DateSend.Replace("/", "");
            id_mess = id_mess.Replace(":", "");
            id_mess = id_mess.Replace(" ", "");
            SetResponse set = cl.Set(@"Messages/" + mess.Sender + "/" + id_mess, mess);
            if (mess.Receiver != "public")
            {
                foreach (KeyValuePair<string, Socket> client in clientSockets)
                {
                    string[] datanew = client.Key.Split('/');
                    if (mess.Receiver == datanew[0])
                    {
                        sendData(client.Value, "0x008|" + data);
                        set = cl.Set(@"Messages/" + mess.Sender + "/" + id_mess + "/", mess);
                        set = cl.Set(@"Messages/" + datanew[0] + "/" + id_mess + "/", mess);
                        return;
                    }
                }
            } else
            {
                set = cl.Set(@"Messages/" + mess.Sender + "/" + id_mess + "/", mess);
                foreach (KeyValuePair<string, Socket> client in clientSockets)
                {
                    if(handler == client.Value)
                    {
                        continue;
                    }
                    string[] datanew = client.Key.Split('/');
                    set = cl.Set(@"Messages/" + datanew[0] + "/" + id_mess + "/", mess);
                    sendData(client.Value, "0x008|" + data);
                }
            }
        }

        static void handlerClientAsync(ref Socket handler, IFirebaseClient client)
        {
            // Xác định là client đã đăng nhập hay chưa (nếu chưa thì login = 0, nếu login rồi thì login = 1)
            int login = 0;
            
            // Vòng lặp để nhận dữ liệu đăng nhập và đăng kí
            while (login == 0)
            {
                // Đợi nhận tín hiệu đăng nhập hoặc đăng kí từ client
                string data_receive = receiveData(handler);
                string[] input = data_receive.Split('|');

                if(input[0] == "0x000")
                {
                    bool check = handlerLogin(handler, client, input[1]);
                    if(check == false)
                    {
                        handler.Close();
                        break;
                    }
                    login = 1;
                } else if(input[0] == "0x001")
                {
                    handlerRegister(handler, client, input[1]);
                    handler.Close();
                    break;
                } else if(input[0] == "0x002")
                {
                    break;
                }
            }

            // Vòng lặp nhận dữ liệu từ client khi client đã login thành công
            while(login == 1)
            {
                string data = receiveData(handler);
                string[] input = data.Split('|');
                if(input[0] == "0x007")
                {
                    handlerMessage(handler, client, input[1]);
                } else if(input[0] == "0x009")
                {
                    clientSockets.Remove(input[1]);
                    foreach(KeyValuePair<string, Socket> user in clientSockets)
                    {
                        sendData(user.Value, "0x009|" + input[1]);
                    }
                    sendData(handler, "0x010| Logout success!");
                    break;
                } else if(input[0] == "0x011")
                {
                    byte[] buffer = new byte[handler.ReceiveBufferSize];
                    int bytesReceived = handler.Receive(buffer);
                    string user_send = "";
                    foreach (KeyValuePair<string, Socket> ct in clientSockets)
                    {
                        if (handler == ct.Value)
                        {
                            string[] usr = ct.Key.Split('/');
                            user_send = usr[1];
                            break;
                        }
                    }
                    if (input[1].Substring(0, 6) == "public")
                    {
                        
                        string[] dt = input[1].Split(',');

                        Message mess = new Message()
                        {
                            Sender = user_send,
                            Receiver = "public",
                            DateSend = dt[1],
                            Text = "Icon"
                        };

                        string id_mess = mess.DateSend.Replace("/", "");
                        id_mess = id_mess.Replace(":", "");
                        id_mess = id_mess.Replace(" ", "");
                        SetResponse set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess, mess);

                        foreach (KeyValuePair<string, Socket> ct in clientSockets)
                        {
                            if (handler == ct.Value)
                            {
                                continue;
                            }
                            string[] usr = ct.Key.Split('/');
                            sendData(ct.Value, "0x011|" + usr[1] + "," + dt[0] + "," + dt[1]);
                            set = client.Set(@"Messages/" + usr[0] + "/" + id_mess + "/", mess);

                            Thread.Sleep(1000);
                            ct.Value.Send(buffer);
                        }
                    } else
                    {
                        string[] dt = input[1].Split(',');
                        Message mess = new Message()
                        {
                            Sender = user_send,
                            Receiver = dt[0],
                            DateSend = dt[2],
                            Text = "Icon"
                        };

                        string id_mess = mess.DateSend.Replace("/", "");
                        id_mess = id_mess.Replace(":", "");
                        id_mess = id_mess.Replace(" ", "");
                        SetResponse set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess, mess);

                        foreach (KeyValuePair<string, Socket> ct in clientSockets)
                        {
                            string compare = dt[0] + "/" + dt[1];
                            if (compare == ct.Key)
                            {
                                sendData(ct.Value, "0x011|" + dt[0] + "," + dt[1] + "," + dt[2]);
                                set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess + "/", mess);
                                set = client.Set(@"Messages/" + mess.Receiver + "/" + id_mess + "/", mess);
                                Thread.Sleep(1000);
                                ct.Value.Send(buffer);
                                break;
                            }
                        }
                    }
                    
                } else if(input[0] == "0x012")

                {
                    //// Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
                    //var stream = File.Open(@"C:\Users\FShop\Documents\Toeic\developing.docx", FileMode.Open, FileAccess.Read);

                    //// Construct FirebaseStorage, path to where you want to upload the file and Put it there
                    //var task = new FirebaseStorage("gs://chatapplication-95820.appspot.com")
                    //    //.Child("appchat")
                    //    //.Child("")
                    //    .Child("developing.docx")
                    //    .PutAsync(stream);

                    //// Track progress of the upload
                    //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    // await the task to wait until upload completes and get the download url
                    //var downloadUrl = task;
                    byte[] buffer = new byte[handler.ReceiveBufferSize];
                    int bytesReceived = handler.Receive(buffer);

                    string user_send = "";
                    foreach (KeyValuePair<string, Socket> ct in clientSockets)
                    {
                        if (handler == ct.Value)
                        {
                            string[] usr = ct.Key.Split('/');
                            user_send = usr[1];
                            break;
                        }
                    }

                    if (input[1].Substring(0, 6) == "public")
                    {
                        string[] dt = input[1].Split(',');
                       

                        Message mess = new Message()
                        {
                            Sender = user_send,
                            Receiver = "public",
                            DateSend = dt[1],
                            Text = dt[2]
                        };

                        string id_mess = mess.DateSend.Replace("/", "");
                        id_mess = id_mess.Replace(":", "");
                        id_mess = id_mess.Replace(" ", "");
                        SetResponse set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess, mess);

                        foreach (KeyValuePair<string, Socket> ct in clientSockets)
                        {
                            if (handler == ct.Value)
                            {
                                continue;
                            }
                            string[] usr = ct.Key.Split('/');
                            sendData(ct.Value, "0x012|" + user_send + "," + dt[1] + "," + dt[2] + "," + "public");
                            set = client.Set(@"Messages/" + usr[0] + "/" + id_mess + "/", mess);
                            Thread.Sleep(1000);
                            ct.Value.Send(buffer);
                        }
                    }
                    else
                    {
                        string[] dt = input[1].Split(',');
                        Message mess = new Message()
                        {
                            Sender = user_send,
                            Receiver = dt[0],
                            DateSend = dt[2],
                            Text = dt[3]
                        };

                        string id_mess = mess.DateSend.Replace("/", "");
                        id_mess = id_mess.Replace(":", "");
                        id_mess = id_mess.Replace(" ", "");
                        SetResponse set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess, mess);
                        foreach (KeyValuePair<string, Socket> ct in clientSockets)
                        {
                            string compare = dt[0] + "/" + dt[1];
                            if (compare == ct.Key)
                            {
                                sendData(ct.Value, "0x012|" + dt[1] + "," + dt[2] + "," + dt[3] + "," + "private");
                                set = client.Set(@"Messages/" + mess.Sender + "/" + id_mess + "/", mess);
                                set = client.Set(@"Messages/" + mess.Receiver + "/" + id_mess + "/", mess);
                                Thread.Sleep(1000);
                                ct.Value.Send(buffer);
                                break;
                            }
                        }
                    }
                } else if(input[0] == "0x013")
                {
                    string[] dt = input[1].Split("/");
                    FirebaseResponse res = client.Get(@"Users/" + dt[0]);
                    User userget = res.ResultAs<User>();
                    userget.Password = dt[1];
                    SetResponse set = client.Set(@"Users/" + dt[0], userget);
                } else if(input[0] == "0x014")
                {
                    Dictionary<string, Message> history = new Dictionary<string, Message>();
                    FirebaseResponse res = client.Get(@"Messages/" + input[1]);
                    history = res.ResultAs<Dictionary<string, Message>>();
                    string userHistory = "0x014";
                    foreach(KeyValuePair<string, Message> hist in history)
                    {
                        Console.WriteLine(hist.Key);
                        userHistory += "|" + JsonConvert.SerializeObject(hist.Value);
                        Console.WriteLine(userHistory);
                    }
                    sendData(handler, userHistory);

                } else if(input[0] == "0x015")
                {
                    FirebaseResponse res = client.Get(@"Users/" + input[1]);
                    User user = res.ResultAs<User>();
                    string user_str = "0x015|" + JsonConvert.SerializeObject(user);
                    sendData(handler, user_str);
                }
            }
            handler.Close();
        }
    }
}
