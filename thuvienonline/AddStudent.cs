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

namespace thuvienonline
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtMail.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String name =txtName.Text;
            String enroll =txtEnrollment.Text;
            String depart =txtDepartment.Text;
            String Sem =txtSemester.Text;
            Int64 Contact =Int64.Parse(txtContact.Text);
            String email =txtMail.Text;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewStudent (name,enroll,depart,sem,contact,email) values ('" + name + "','" + enroll + "',+'" + depart + "','" + Sem+"',"+Contact+",'"+email+"')" ;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data saved!", "SuccessFUll", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
