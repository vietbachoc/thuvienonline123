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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database =Library_management_system;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd = new SqlCommand("select Book_Name from Books", con);
            SqlDataReader Sdr =cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for(int i = 0;i < Sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int count;
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtEnrollment.Text != "")
            {
                String eid = txtEnrollment.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Students where enroll ='" + eid +"' ";
                SqlDataAdapter Da =new SqlDataAdapter(cmd);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);


                cmd.CommandText = "select count(Student_Enrollment) from IssuedBooks where Student_Enrollment  ='" + eid + "' and Book_Return_Date is null";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                Da.Fill(DS);

                count = int.Parse(DS.Tables[0].Rows[0][0].ToString());




                if (Ds.Tables[0].Rows.Count !=0) 
                {
                    txtName.Text = Ds.Tables[0].Rows[0][1].ToString();
                    txtDep.Text = Ds.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = Ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = Ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = Ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    txtName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssueB_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                if(comboBox1.SelectedIndex != -1  && count <=2) 
                {
                    String enroll = txtEnrollment.Text;
                    String sname = txtName.Text;
                    String sdep = txtDep.Text;
                    String ssem = txtSem.Text; 
                    Int64 scontact = Int64.Parse(txtContact.Text);
                    String email =txtEmail.Text;
                    String Bookname = comboBox1.Text;
                    String BookIssuedate = dateTimePicker1.Text;

                    String eid = txtEnrollment.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database =Library_management_system;integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IssuedBooks (Student_Enrollment,Student_Name,Student_Department,Student_Semester,Student_Contact,Student_Email,Book_Name,Book_Issue_Date) values ('" + enroll + "','" + sname + "','" + sdep + "','" + ssem + "'," + scontact + ",'" + email + "','" + Bookname + "','" + BookIssuedate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("select Book. Or Maximum number of Book Has been Issued","No Book Selected",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollment NO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollment.Text == "")
            {
                txtName.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
