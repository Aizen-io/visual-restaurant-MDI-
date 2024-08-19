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
    public partial class Chicken : Form
    {
        public Chicken()
        {
            InitializeComponent();
            showChicken();
        }
    
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
       CHOPSDataSet CHOPS = new CHOPSDataSet();
        BindingSource CHOPS_LOG = new BindingSource();
        private void Chicken_Load(object sender, EventArgs e)
        {

        }
        private void showChicken()
        {
            con.Open();
            string query = "select * from ChickenTable";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
