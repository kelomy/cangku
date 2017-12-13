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
    public partial class userchange : Form
    {
        public userchange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交修改吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                dbhelper.connection.Open();
                string sql = string.Format("update Users set UID='{0}',UName='{1}',USex='{2}',UTel='{3}',UAdd='{4}', UDep='{5}' where UID='{6}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox1.Text);
                SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                com.ExecuteNonQuery();
                dbhelper.connection.Close();
                MessageBox.Show("成功", "提示");
            }
            else
            {
                MessageBox.Show("失败", "提示");
            }
        }

        private void userchange_Load(object sender, EventArgs e)
        {

        }
    }
}