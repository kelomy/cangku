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
    public partial class usermanage : Form
    {
        public usermanage()
        {
            InitializeComponent();
        }

        private void usermanage_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = string.Format("select UID as 账号,UPassword as 密码,UPower as 权限,UName as 姓名,USex as 性别,UTel as 电话,UAdd as 地址,UDep as 所属仓库 from Users");
            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form fm = new useradd();
            fm.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
           {
               string sql=string.Format("delete from Users where UID='{0}'",dataGridView1.CurrentRow.Cells[0].Value.ToString());
               dbhelper.connection.Open();
               SqlCommand com=new SqlCommand(sql,dbhelper.connection);
               com.ExecuteNonQuery();
               MessageBox.Show("操作成功");
               string sqll = string.Format("select UID as 账号,UPassword as 密码,UPower as 权限,UName as 姓名,USex as 性别,UTel as 电话,UAdd as 地址,UDep as 所属仓库 from Users");
               SqlCommand com1 = new SqlCommand(sqll, dbhelper.connection);
               SqlDataAdapter adapter1 = new SqlDataAdapter();
               DataSet DS1 = new DataSet();

               adapter1.SelectCommand = com1;
               adapter1.Fill(DS1);
               dataGridView1.DataSource = DS1.Tables[0];
               dbhelper.connection.Close();
           }
          
        }

        private void change_Click(object sender, EventArgs e)
        {
            userchange fm = new userchange();
            
            fm.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            fm.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            fm.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            fm.textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            fm.textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            fm.textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
            fm.Show();
        }

        private void select_Click(object sender, EventArgs e)
        {

        }
    }
}