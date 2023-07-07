using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace BaiTap
{
    public partial class Form7 : Form
    {
        private string url;
        public Form7(string url)
        {
            InitializeComponent();
            this.url = url;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(url);
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = webBrowser1.DocumentText;
            Form8 f8 = new Form8(html);
            f8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                     filePath = openFileDialog.FileName;
                }
            }

            WebClient client = new WebClient();

            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            string imgDirectory = "C:\\Users\\FShop\\Documents\\LTMCB_TH\\Lab4\\Images";

            HtmlNodeCollection imgNodes = doc.DocumentNode.SelectNodes("//img");

            if (imgNodes != null)
            {
                foreach (HtmlNode imgNode in imgNodes)
                {
                    string imgUrl = imgNode.GetAttributeValue("src", "");
                    if (!string.IsNullOrEmpty(imgUrl))
                    {
                        string imgFileName = Path.GetFileName(imgUrl);
                        string imgFilePath = Path.Combine(imgDirectory, imgFileName);
                        using (File.Create(imgFilePath))
                        {
                            
                        }
                        client.DownloadFile(url + imgUrl, imgFilePath);
                        imgNode.SetAttributeValue("src", "Images/" + imgFileName);
                    }
                }
            }
            using (var stream = new StreamWriter(filePath))
            {
                doc.Save(stream);
            }
        }
    }
}
