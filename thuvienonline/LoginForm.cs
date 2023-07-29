using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace thuvienonline
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if( txtusername.Text== "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar= '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from LoginTb where username ='" + txtusername + "' and password='" + txtpassword.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                dashboard dsa = new dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
