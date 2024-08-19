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
    public partial class AddSandwich : Form
    {
        public AddSandwich()
        {
            InitializeComponent();
            showSandwich();
        }
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
      
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
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
        private void AddSandwich_Load(object sender, EventArgs e)
        {

        }

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
                    SqlCommand cmd = new SqlCommand("Insert into SandwichTable" + "(name,des,price)values(@SN,@SD,@SP)", con);
                    cmd.Parameters.AddWithValue("@SN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SP", textBox3.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sandwich Added");
                    con.Close();
                    showSandwich();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int key = 0;
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
                    SqlCommand cmd = new SqlCommand("Update SandwichTable set name=@SN,des=@SD,price=@SP where Id=@SKey", con);
                    cmd.Parameters.AddWithValue("@SN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SP", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SKey", key);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sandwich Menu Updated");
                    showSandwich();
                    Reset();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.Close(); }
            }
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
                    MessageBox.Show("Sandwich Deleted");
                    showSandwich();
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
    }
}
