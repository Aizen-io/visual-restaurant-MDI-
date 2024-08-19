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
    public partial class AddBurger : Form
    {
        public AddBurger()
        {
            InitializeComponent();
            showBurger();
        }
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all the info");
            }
            else
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into BurgerTable" + "(name,des,price)values(@BN,@BD,@BP)", con);
                    cmd.Parameters.AddWithValue("@BN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@BP", textBox3.Text);
                 
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Burger Added");
                    con.Close();
                    showBurger();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

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
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Meal to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from BurgerTable where Id=@CKey", con);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Burger Deleted");
                    showBurger();
                    Reset();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update BurgerTable set name=@BN,des=@BD,price=@BP where Id=@SKey", con);
                    cmd.Parameters.AddWithValue("@BN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@BP", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SKey", key);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Burger Menu Updated");
                   showBurger();
                    Reset();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.Close(); }
            }
        }

        private void AddBurger_Load(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            if (txtID.Text == "")
            {
                key = 0;

            }
            else
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
