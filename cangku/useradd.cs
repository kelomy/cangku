using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security;

namespace cangku
{
    public partial class useradd : Form
    {
        public useradd()
        {
            InitializeComponent();
        }

        private void useradd_Load(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = "select WID  from Warehouses";


            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet DS = new DataSet();

            adapter.SelectCommand = com;
            adapter.Fill(DS);
            comboBox2.DataSource = DS.Tables[0];
            comboBox2.DisplayMember = "WID";
            comboBox2.ValueMember = "WID";
            dbhelper.connection.Close();
            comboBox2.Text = "";
           
        }
       


        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || comboBox1.Text.Trim() == "")
                    MessageBox.Show("请输入完整信息!", "警告");
                else
                {
                    if (textBox2.Text.Trim() != textBox3.Text.Trim())
                        MessageBox.Show("两次密码输入不一致!", "警告");
                    else
                    {

                        string tt = MD5Encrypt.MD5Manager.Md5Encrypt(textBox2.Text.Trim());

                        dbhelper.connection.Open();
                        string sql = string.Format("select * from Users where UID='{0}'", textBox1.Text.Trim());
                        SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                        if (null == com.ExecuteScalar())
                        {
                            string sex = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
                            string sqll = string.Format("insert into Users values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", textBox1.Text.Trim(), tt, comboBox1.Text, textBox4.Text.Trim(), sex, textBox5.Text.Trim(), textBox6.Text.Trim(), comboBox2.Text);
                            com.CommandText = sqll;
                            com.ExecuteNonQuery();
                            MessageBox.Show("添加用户成功!", "提示");
                        }
                        else
                        {
                            MessageBox.Show("用户已经存在!", "提示");
                        }
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
    }
}