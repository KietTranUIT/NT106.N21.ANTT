using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap
{
    public partial class Form8 : Form
    {
        private string html;
        public Form8(string html)
        {
            InitializeComponent();
            this.html = html;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = html;
        }
    }
}
