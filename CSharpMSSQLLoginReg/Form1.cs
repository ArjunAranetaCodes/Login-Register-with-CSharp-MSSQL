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

namespace CSharpMSSQLLoginReg
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=ALLMANKIND\\MSSQLSERVER8; Database=db_csloginreg; Integrated Security=True;");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new SqlDataAdapter("insert into tbl_accounts (username, password) VALUES " +
             "('" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            adapter.Fill(ds, "tbl_accounts");
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show("User Registered!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new SqlDataAdapter("select * from tbl_accounts where username like '" + textBox1.Text + 
                "' and password like '" + textBox2.Text + "'", conn);
            adapter.Fill(ds, "tbl_accounts");

            if (ds.Tables["tbl_accounts"].Rows.Count > 0)
            {
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Invalid username and password");
            }
        }
    }
}
