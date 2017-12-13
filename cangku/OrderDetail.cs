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
    public partial class OrderDetail : Form
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select FID as 货品编号,SWID as 仓库编号,SQuantity as 现有数量,SbLine as 数量下限,STLine as 数量上限,FPrice as 当前价格,FProvider1 as 住供应商,FProvider2  as 次供应商 from Fruits , Store where Fruits.FID=Store.SFID";


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

           adapter.SelectCommand = com;
          adapter.Fill(DS);
          dataGridView1.DataSource = DS.Tables[0];
          dbhelper.connection.Close();
          label4.Text = "共有" + DS.Tables[0].Rows.Count + "条查询记录";
          textBox1.Text = "";
         
          textBox3.Text = "";
        }

       

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = string.Format("select FID as 货品编号,SWID as 仓库编号,SQuantity as 现有数量,SbLine as 数量下限,STLine as 数量上限,FPrice as 当前价格,FProvider1 as 住供应商,FProvider2  as 次供应商 from Fruits , Store where Fruits.FID=Store.SFID and Store.SWID like '%{0}%' and Fruits.FID like '%{1}%'", textBox3.Text,textBox1.Text);


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
            label4.Text = "共有" + DS.Tables[0].Rows.Count + "条查询记录";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daochuEXCEL.ExportExcel("库存信息", this.dataGridView1);
        }

        
    }
}