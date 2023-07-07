using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai1 form = new Bai1();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai2 form = new Bai2();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai3 form = new Bai3();
            form.ShowDialog();
        }
    }
}
