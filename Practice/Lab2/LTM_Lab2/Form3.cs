using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LTM_Lab2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            // Read file
            string contentFile = sr.ReadToEnd();
            richTextBox1.Text = contentFile;
            // Name file
            string nameFile = ofd.SafeFileName.ToString();
            textBox1.Text = nameFile;
            // Url file
            string urlFile = fs.Name.ToString();
            textBox2.Text = urlFile;
            // Count number of line in file
            //int countLine = 0;
            //while(sr.ReadLine() != null)
            //{
            //    countLine++;
            //}
            string[] countLine = contentFile.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            textBox3.Text = countLine.Length.ToString();
            // Count number of character in file
            textBox5.Text = contentFile.Length.ToString();
            // Count number of word in file
            char[] characterSplits = new char[] { '.', '?', '!', ' ', ';', ',' };
            contentFile = contentFile.Replace("\r\n", "\r");
            contentFile = contentFile.Replace("\r", " ");
            string[] source = contentFile.Split(characterSplits, StringSplitOptions.RemoveEmptyEntries);
            textBox4.Text = source.Length.ToString();
            sr.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
