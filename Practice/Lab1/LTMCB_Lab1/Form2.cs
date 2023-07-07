using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LTMCB_Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOne, numberTwo;
            long sum;
            numberOne = Int32.Parse(textBox1.Text.Trim());
            numberTwo = Int32.Parse(textBox2.Text.Trim());
            sum = numberOne + numberTwo;
            textBox3.Text = sum.ToString();
        }
    }
}
