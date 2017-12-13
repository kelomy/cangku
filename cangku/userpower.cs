using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace cangku
{
    public partial class userpower : Form
    {
        public userpower()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = string.Format("update Users set UPower='{0}' where UID='{1}'", comboBox1.Text,textBox1.Text.Trim() );
            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            if (com.ExecuteNonQuery()!=0)
                MessageBox.Show("更改成功!", "提示");
            else
                MessageBox.Show("无此用户", "警告");
            dbhelper.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userpower_Load(object sender, EventArgs e)
        {

        }
    }
}