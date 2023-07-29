using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thuvienonline
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you want to Exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addbooks abs = new Addbooks();
            abs.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();  
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            vs.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook Is = new IssueBook();
            Is.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }

        private void booksDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksDetail bd = new BooksDetail();
            bd.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
