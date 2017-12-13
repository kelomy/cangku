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
    public partial class WarehouseAdd : Form
    {
        public WarehouseAdd()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("*信息不能为空!");
                else
                {
                    dbhelper.connection.Open();
                    string sql = string.Format("select * from Warehouses where WName='{0}'", textBox1.Text.Trim());
                    SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                    if (com.ExecuteScalar() != null)
                        MessageBox.Show("仓库信息已经存在");
                    else
                    {
                        string sqll = string.Format("insert into Warehouses ( WID,WName,WArea,WAdd,WDeb) values ('{0}','{1}','{2}','{3}',{4})",textBox5.Text, textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                        com = new SqlCommand(sqll, dbhelper.connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("添加信息成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                dbhelper.connection.Close();
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WarehouseAdd_Load(object sender, EventArgs e)
        {

        }
    }
}