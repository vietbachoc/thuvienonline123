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
    public partial class Addbooks : Form
    {
        public Addbooks()
        {
            InitializeComponent();
        }

        private void Addbooks_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            String bname = txtbname.Text;
            String bauthor = txtbauthor.Text;
            String publication = txtpublication.Text;
            String pdate = dateTimePicker1.Text;
            Int64 price = Int64.Parse(txtbprice.Text);
            Int64 quan = Int64.Parse(txtbquan.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =LAPTOP-OVGA86OH\\SQLEXPRESS; database = newlibrary; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= con;

            con.Open();
            cmd.CommandText = "insert into NewBook (bName,bAuthor,bpubl,bPdate,bPrice,bQuan) values ('" + bname + "','" + bauthor + "','" + publication + "','" + pdate + "'," + price + "," + quan + ")";
            cmd.ExecuteNonQuery();  
            con.Close();
            
            MessageBox.Show("Your Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("This will Delete your Unsaved Data.","Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
            {
                this.Close();
            }
        }
    }
}
