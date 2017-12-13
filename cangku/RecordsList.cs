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
    public partial class RecordsList : Form
    {
        public RecordsList()
        {
            InitializeComponent();
        }

        private void RecordsList_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select RID as 编号 , RFID as 货品编号,RWID as 仓库编号,RQuantity as 进出数量, RType as 操作类型,RManager as 管理人员,RHandler as 经手人,RDate as 日期 from Records ";


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dbhelper.connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fm = new goodsReserve();
            fm.Show();
          
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                string sql = string.Format("delete from Records where FID='{0}' ", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dbhelper.connection.Open();
                SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                com.ExecuteNonQuery();
                MessageBox.Show("操作成功");
                dbhelper.connection.Close();
               
            }
            RecordsList_Load(sender, e);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            daochuEXCEL.ExportExcel("入|出库单", this.dataGridView1);
        }

       
    }
}