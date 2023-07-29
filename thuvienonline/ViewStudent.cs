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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace thuvienonline
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * From NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet Ds = new DataSet();
            DA.Fill(Ds);

            dataGridView1.DataSource = Ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * From NewStudent where enroll LIKE '"+txtSEnrollment.Text+"%'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet Ds = new DataSet();
            DA.Fill(Ds);
            
            dataGridView1.DataSource= Ds.Tables[0];
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * From NewStudent where enroll LIKE '" + txtSEnrollment.Text + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet Ds = new DataSet();
            DA.Fill(Ds);

            rowid = Int64.Parse(Ds.Tables[0].Rows[0][0].ToString());

            txtSName.Text = Ds.Tables[0].Rows[0][1].ToString();
            txtSenroll.Text = Ds.Tables[0].Rows[0][2].ToString();
            txtSDep.Text = Ds.Tables[0].Rows[0][3].ToString();
            txtSSem.Text = Ds.Tables[0].Rows[0][4].ToString();
            txtSContact.Text = Ds.Tables[0].Rows[0][5].ToString();
            txtSemail.Text = Ds.Tables[0].Rows[0][6].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sname = txtSName.Text;
            String enroll =txtSenroll.Text;
            String dep = txtSDep.Text;
            String sem = txtSSem.Text;
            String contact = txtSContact.Text;
            String semail = txtSemail.Text;


            if (MessageBox.Show("Data will be Update. ConFirm ?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update NewStudent set name = '" + sname + "',enroll = '" + enroll + "',depart = '" + dep + "',sem ='" + sem + "',contact = '" + contact + "',email ='" + semail + "' where id =" + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet Ds = new DataSet();
                DA.Fill(Ds);

                
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Delete. ConFirm ?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from Newstudent where id = "+rowid+ "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet Ds = new DataSet();
                DA.Fill(Ds);

                
            }
        }
    }
} 
