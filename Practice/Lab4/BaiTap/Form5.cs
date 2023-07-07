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
using System.IO;

using DocHtml = HtmlAgilityPack.HtmlDocument;

namespace BaiTap
{
    public partial class Form5 : Form
    {
        private bool IsValidUrl(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            if (IsValidUrl(url) == false)
            {
                MessageBox.Show("Invalid url, try again");
            }
            string filepath = textBox2.Text;
            if (Directory.Exists(filepath) == true)
            {
                MessageBox.Show("File exists");
            }
            WebClient client = new WebClient();
            client.DownloadFile(url, filepath);

            DocHtml doc = new DocHtml();
            doc.Load(filepath);
            Encoding utf8 = Encoding.UTF8;
            byte[] htmlBytes = utf8.GetBytes(doc.DocumentNode.OuterHtml);
            richTextBox1.Text = utf8.GetString(htmlBytes);
        }
    }
}
