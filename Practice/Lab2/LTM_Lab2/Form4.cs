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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                DataTable table = new DataTable();
                string content;
                foreach (string line in richTextBox1.Lines)
                {
                    if (line == "")
                    {
                        break;
                    }
                    content = line.Replace("\n", "");
                try
                {
                    var result = table.Compute(content, "");
                    sw.WriteLine(content + " = " + result.ToString());
                }
                catch (SyntaxErrorException ex)
                {
                    MessageBox.Show("Lỗi cú pháp!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi");
                }
                }
                sw.Close();
                fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
