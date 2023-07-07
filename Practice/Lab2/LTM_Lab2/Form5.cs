using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LTM_Lab2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();

            // Đọc file
            StreamReader str = new StreamReader(ofd.FileName);

            while (!str.EndOfStream)
            {
                try
                {
                    string mssv = str.ReadLine();
                    richTextBox1.Text += mssv + "\n";
                    string name = str.ReadLine();
                    richTextBox1.Text += name + "\n";
                    string n_phone = str.ReadLine();
                    richTextBox1.Text += n_phone + "\n";

                    float score_math = float.Parse(str.ReadLine());
                    richTextBox1.Text += score_math.ToString() + "\n";

                    float score_literature = float.Parse(str.ReadLine());
                    richTextBox1.Text += score_literature.ToString() + "\n\n";

                    float score_average = (score_math + score_literature) / 2;

                    // Hàng trống.
                    str.ReadLine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File input không đúng định dạng.", "Lỗi.", MessageBoxButtons.OK);
                }
            }
            str.Close();
            richTextBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "OutputB4.txt";

            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.ShowDialog();
            FileStream fs = new FileStream(ofd1.FileName, FileMode.Create);

            StreamWriter stw = new StreamWriter(fs);
            StreamReader str = new StreamReader(ofd.FileName);
            if (!File.Exists(path))
                File.CreateText(path);
            else
            {
                while (!str.EndOfStream)
                {
                    try
                    {
                        string mssv = str.ReadLine();
                        stw.WriteLine(mssv);

                        string name = str.ReadLine();
                        stw.WriteLine(name);

                        string n_phone = str.ReadLine();
                        stw.WriteLine(n_phone);

                        float score_math = float.Parse(str.ReadLine());
                        stw.WriteLine(score_math.ToString());

                        float score_literature = float.Parse(str.ReadLine());
                        stw.WriteLine(score_literature.ToString());

                        float score_average = (score_math + score_literature) / 2;
                        stw.WriteLine(score_average.ToString());

                        // Hàng trống.
                        stw.WriteLine("\n");
                        str.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File input không đúng định dạng.", "Lỗi.", MessageBoxButtons.OK);
                    }

                }
            }
            stw.Close();
            str.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
