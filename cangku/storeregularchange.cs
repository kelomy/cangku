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
    public partial class storeregularchange : Form
    {
        public storeregularchange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交修改吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                dbhelper.connection.Open();
                string sql = string.Format("update Store set SFID='{0}',SWID='{1}',STLine='{2}',SbLine='{3}'where SFID='{4}' and SWID='{5}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text);
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

        private void storeregularchange_Load(object sender, EventArgs e)
        {

        }
    }
}