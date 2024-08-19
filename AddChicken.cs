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
    public partial class AddChicken : Form
    {
        public AddChicken()
        {
            InitializeComponent();
            showChicken();

        }
        SqlConnection con = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;
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
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

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
                    SqlCommand cmd = new SqlCommand("Insert into ChickenTable" + "(name,des,price)values(@CN,@CD,@CP)", con);
                    cmd.Parameters.AddWithValue("@CN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CP", textBox3.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Chiken Added");
                    con.Close();
                    showChicken();
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
                    SqlCommand cmd = new SqlCommand("Update ChickenTable set name=@CN,des=@CD,price=@CP where Id=@SKey", con);
                    cmd.Parameters.AddWithValue("@CN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CD", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CP", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SKey", key);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Chicken Menu Updated");
                    showChicken();
                    Reset();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.Close(); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select meal to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ChickenTable where Id=@CKey", con);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Chicken Deleted");
                    showChicken();
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

        private void AddChicken_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

