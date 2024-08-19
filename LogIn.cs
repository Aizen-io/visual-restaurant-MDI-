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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=Localhost;Initial Catalog=CHOPS;Integrated Security=True");
        SqlCommand cmd;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPass.Text=="Admin" || txtUserName.Text == "Admin")
                {
                    Form1 a = new Form1();
                    a.Show();

                }
                else
                if (txtPass.Text != string.Empty || txtUserName.Text != string.Empty)
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from UserTable where username='" + txtUserName.Text + "' and password='" + txtPass.Text + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        menu Home = new menu();
                       
                        Home.Show();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cn.Close(); }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Check your email");
        }
    }
}
