using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;

namespace BaiTap
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async Task<string> SendData(string url, string data)
        {
            using (var waitform = new Form4())
            {
                waitform.Show();
                try
                {
                    using (var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded"))
                    {
                        using (var client = new HttpClient())
                        {
                            var response = await client.PostAsync(url, content);
                            var responseString = await response.Content.ReadAsStringAsync();
                            return responseString;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    waitform.Close();
                }
                    }
                }
        private async void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string data = textBox2.Text;
            string result = await SendData(url, data);
            richTextBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void TextBox1_Set(TextBox textbox)
        {
            textbox.Text = "http://www.contoso.com/PostAccepter.aspx";
            textbox.ReadOnly = true;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            TextBox1_Set(textBox1);
        }
    }
}
