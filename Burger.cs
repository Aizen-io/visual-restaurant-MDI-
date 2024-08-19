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
    public partial class Burger : Form
    {
        public Burger()
        {
            InitializeComponent();
            showBurger();
        }
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        private void Burger_Load(object sender, EventArgs e)
        {

        }
        private void showBurger()
        {
            con.Open();
            string query = "select * from BurgerTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
