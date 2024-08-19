using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kfcProjectt
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            
        }
        SqlConnection cn = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
        private void Order_Load(object sender, EventArgs e)
        {

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }
    }
}
