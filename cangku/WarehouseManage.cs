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
    public partial class WarehouseManage : Form
    {
        public WarehouseManage()
        {
            InitializeComponent();
        }

        private void WarehouseManage_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select WID as 仓库编号,WName as 名称,WArea as 容积,WAdd as 地址,WDeb as 简单描述 from Warehouses ";


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
        }//初始化

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                int wid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string sql = string.Format("delete from Warehouses where WID='{0}'", wid);
                dbhelper.connection.Open();
                SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                com.ExecuteNonQuery();
               
                dbhelper.connection.Close();
                MessageBox.Show("成功", "提示");
            }
            else
                MessageBox.Show("操作失败!", "提示");
        }//删除

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//退出

        private void btnchange_Click(object sender, EventArgs e)
        {
            warehousechange fm = new warehousechange();
            fm.label10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            fm.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            fm.textBox2.Text =Convert.ToString( dataGridView1.CurrentRow.Cells[2].Value);
            fm.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            fm.textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            fm.Show();
           
           
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fm = new WarehouseAdd();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            daochuEXCEL.ExportExcel("仓库信息", this.dataGridView1);
        }

        

       
    }
}