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

namespace WindowsFormsApp001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("เครื่องเขียน");
            comboBox1.Items.Add("สมุด");
            comboBox1.Items.Add("กระดาษ");
            comboBox1.Items.Add("แฟ้ม");
            comboBox1.Items.Add("อุปกรณ์สำนักงาน");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection DBs = new SQLiteConnection("Data Source=C:/Users/user/Desktop/Database/pro.db;");
            string query = "INSERT INTO Product(TypePro, amountPro, datePro) VALUES('" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + numericUpDown1.Text + "')";

            SQLiteCommand cmd = new SQLiteCommand(query, DBs);
            DBs.Open();
            cmd.ExecuteNonQuery();
            DBs.Close();
            MessageBox.Show("เพิ่มรายการเรียบร้อย");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
    
}
