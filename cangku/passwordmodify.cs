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
    public partial class passwordmodify : Form
    {
        public passwordmodify()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                    MessageBox.Show("请填写完整信息!", "提示");
                else
                {
                    dbhelper.connection.Open();
                    string sql = string.Format("select * from Users where UID='{0}' ", textBox1.Text.Trim());
                    SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                  
                    
                    
                    if (com.ExecuteScalar().ToString()!="")
                    {
                        if (textBox3.Text.Trim() != textBox4.Text.Trim())
                            MessageBox.Show("两次密码输入不一致!", "警告");
                        else
                        {
                            string tt = MD5Encrypt.MD5Manager.Md5Encrypt(textBox3.Text.Trim());
                            string sqll = string.Format("update Users set UPassword='{0}' where UID='{1}'", tt, textBox1.Text.Trim());
                            com.CommandText = sqll;
                            com.ExecuteNonQuery();
                            MessageBox.Show("密码修改成功!", "提示");
                        }
                    }
                    else
                        MessageBox.Show("用户名错误!", "提示");
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

        private void passwordmodify_Load(object sender, EventArgs e)
        {

        }
    }
}