using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace thuvienonline
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible= false;
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database =Library_management_system;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmd.CommandText = "select * from IssuedBooks where Student_Enrollment='" + txtEnterEnroll.Text+ "' and Book_Return_Date  IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count != 0 )
            {
                dataGridView1.DataSource = ds.Tables[0];
            }   
            else
            {
                MessageBox.Show("Inavalid Id or No Book Issue","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;    
            txtEnterEnroll.Clear();
        }
        String bname;
        String bdate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            txtBookIssuedate.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database =Library_management_system;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IssuedBooks set Book_Return_Date  ='" + dateTimePicker1.Text + "'where Student_Enrollment='" + txtEnterEnroll.Text+"' and id= '"+rowid+"'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Succesful.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }

        private void txtEnterEnroll_TextChanged(object sender, EventArgs e)
        {
            if (txtEnterEnroll.Text == "")
            {
                panel4.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
