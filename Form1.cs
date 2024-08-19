using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kfcProjectt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddBurger b = new AddBurger();
            b.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddChicken b = new AddChicken();
            b.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSandwich b = new AddSandwich();
            b.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
