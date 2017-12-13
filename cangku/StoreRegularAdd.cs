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
    public partial class StoreRegularAdd : Form
    {
        public StoreRegularAdd()
        {
            InitializeComponent();
        }

        private void StoreRegularAdd_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select WID from Warehouses";
            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();
            adapter.SelectCommand = com;
            adapter.Fill(DS);
            comboBox2.DataSource = DS.Tables[0];
            comboBox2.DisplayMember = "WID";
            comboBox2.ValueMember = "WID";
            dbhelper.connection.Close();
            dbhelper.connection.Open();
            string sqll = "select FID from Fruits";
            SqlCommand com1 = new SqlCommand(sqll, dbhelper.connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataSet DS1 = new DataSet();
            adapter1.SelectCommand = com1;
            adapter1.Fill(DS1);
            comboBox1.DataSource = DS1.Tables[0];
            comboBox1.DisplayMember = "FID";
            comboBox1.ValueMember = "FID";
            dbhelper.connection.Close();
           
            comboBox1.Text = "";
            comboBox2.Text = "";

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("信息不能为空");
                else
                {
                    if (Convert.ToInt32(textBox1.Text) > Convert.ToInt32(textBox2.Text))
                    {
                        dbhelper.connection.Open();
                        string sql = string.Format("select * from Store where SFID='{0}' and SWID='{1}'", comboBox1.Text, comboBox2.Text);
                        SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                        if (com.ExecuteScalar() == null)
                        {
                            string sqll = string.Format("insert into Store(SFID,SWID,STLine,SbLine) values('{0}','{1}','{2}','{3}')", comboBox1.Text, comboBox2.Text, textBox1.Text, textBox2.Text);
                            com.CommandText = sqll;
                            com.ExecuteNonQuery();
                            MessageBox.Show("信息添加成功!", "提示");
                        }
                        else
                        {
                            MessageBox.Show("规则不能重复!", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("上限需大于下限!", "警告");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}