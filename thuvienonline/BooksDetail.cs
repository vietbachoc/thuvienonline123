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

namespace thuvienonline
{
    public partial class BooksDetail : Form
    {
        public BooksDetail()
        {
            InitializeComponent();
        }

        private void BooksDetail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IssueBook where BookReturn_date is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];

            cmd.CommandText = "select * from IssueBook where BookReturn_date is not null";
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet Ds = new DataSet();
            Da.Fill(Ds);
            dataGridView2.DataSource= ds.Tables[0];
        }
    }
}
