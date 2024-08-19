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
    public partial class Sandwich : Form
    {
        public Sandwich()
        {
            InitializeComponent();
            showSandwich();
        }
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
        private void Sandwich_Load(object sender, EventArgs e)
        {

        }
        private void showSandwich()
        {
            con.Open();
            string query = "select * from SandwichTable";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
