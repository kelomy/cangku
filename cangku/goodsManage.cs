using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
namespace cangku
{
    public partial class goodsManage : Form
    {
        public goodsManage()
        {
            InitializeComponent();
        }

        private void goodsManage_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select FID as 货品编号,FName as 名称,FPrice as 市场价,FUnit as 单位,FProvider1 as 主供应商,FProvider2  as 次供应商,FDescribe as 备注 from Fruits";
            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
           
        }

       

        private void search_Click(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = string.Format("select FID as 货品编号,FName as 名称,FPrice as 市场价,FUnit as 单位,FProvider1 as 主供应商,FProvider2  as 次供应商,FDescribe as 备注 from Fruits where FID like '%{0}%'and FName like '%{1}%'", textBox1.Text.Trim(), textBox2.Text.Trim());


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            daochuEXCEL.ExportExcel("货品信息",this.dataGridView1);
        }
 

    }
}