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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBookSearch.Clear();
            panel3.Visible= false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBookSearch.Text != "")
            {
                panel3.Visible = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Books where Book_Name LIKE '" + txtBookSearch.Text +"%'" ;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                panel3.Visible = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Books";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Books";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0]; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel3.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Books where Book_ID= " + bid +"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtBPublication.Text = ds.Tables[0].Rows[0][3].ToString(); 
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString(); 
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel3.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Update. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bauthor = txtBAuthor.Text;
                String publication = txtBPublication.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                String pdate = txtPDate.Text;
                Int64 quan = Int64.Parse(txtQuantity.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Books set Book_Name= '" + bname + "', Book_Author = '" + bauthor + "',Book_Publisher = '" + publication + "',Book_Publish_Date= '" + pdate + "', Book_Price = " + price + ",Book_Quantity = " + quan + " where Book_ID = " + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Delete. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bauthor = txtBAuthor.Text;
                String publication = txtBPublication.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                String pdate = txtPDate.Text;
                Int64 quan = Int64.Parse(txtQuantity.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = Library_management_system;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Books where Book_ID =" + rowid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
