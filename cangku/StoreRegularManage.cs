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
    public partial class StoreRegularManage : Form
    {
        public StoreRegularManage()
        {
            InitializeComponent();
        }

        private void StoreRegularManage_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select SFID as 货品编号,SWID as 仓库编号,STLine as 数量上限,SbLine as 数量下限 from Store";

            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Form fm = new StoreRegularAdd();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                string sql = string.Format("delete from Store where SFID='{0}' and SWID='{1}'", dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
                dbhelper.connection.Open();
                SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                com.ExecuteNonQuery();
                MessageBox.Show("操作成功");
                string sqll = "select SFID as 货品编号,SWID as 仓库编号,STLine as 数量上限,SbLine as 数量下限 from Store";

                SqlCommand com1 = new SqlCommand(sqll, dbhelper.connection);
                SqlDataAdapter adapter1 = new SqlDataAdapter();
                DataSet DS1 = new DataSet();

                adapter1.SelectCommand = com1;
                adapter1.Fill(DS1);
                dataGridView1.DataSource = DS1.Tables[0];
                dbhelper.connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            storeregularchange fm = new storeregularchange();
           
            fm.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            fm.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            fm.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            fm.textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            fm.Show();
           
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            daochuEXCEL.ExportExcel("规则信息", this.dataGridView1);
        }
    }
}