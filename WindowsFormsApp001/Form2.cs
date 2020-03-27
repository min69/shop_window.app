using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace WindowsFormsApp001
{
     public partial class Form2 : Form
    {
        static int attempt = 3;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (attempt == 0)
            {
                textBox1.Text = ("ALL 3 ATTEMPTS HAVE FAILED - CONTACT ADMIN");
                return;
            }
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=DESKTOP-QTMTID2\SQLEXPRESS;Initial Catalog=login_database;database=login;integrated security=SSPI";
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from login_database where username=@usr and password=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox2.Text);
            scn.Open();

            if (scmd.ExecuteScalar().ToString() == "1")
            {
               
                MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
            }

            else
            {

                
                MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");
                textBox1.Text = ("You Have Only " + Convert.ToString(attempt) + " Attempt Left To Try");
                --attempt;
                textBox1.Clear();
                textBox2.Clear();
            }
            scn.Close();

        }
    }
}