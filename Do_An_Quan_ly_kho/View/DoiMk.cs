using Do_An_Quan_ly_kho.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Quan_ly_kho.View
{
    public partial class DoiMk : Form
    {
        public DoiMk()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mkcu = textBox1.Text;
            var mkmoi = textBox2.Text;
            var nhaplaimk = textBox3.Text;

            DoiMkController check = new DoiMkController();
            check.XulyDoiMk(mkcu, mkmoi, nhaplaimk, this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
