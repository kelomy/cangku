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
    public partial class warehousechange : Form
    {
        public warehousechange()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交修改吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                dbhelper.connection.Open();
                string sql = string.Format("update Warehouses set WName='{0}',WArea='{1}',WAdd='{2}',WDeb='{3}'where WID='{4}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,Convert.ToInt32(label10.Text));
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

        private void warehousechange_Load(object sender, EventArgs e)
        {

        }
    }
}