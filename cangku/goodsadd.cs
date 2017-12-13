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
    public partial class goodsAdd : Form
    {
        public goodsAdd()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text.Trim().Length != 6)
                {
                    MessageBox.Show("货品号格式不对！");
                }
                else
                {
                    if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "" && textBox6.Text.Trim() == "")
                    {
                        MessageBox.Show("*不能为空");
                    }
                    else
                    {
                        dbhelper.connection.Open();
                        string sql = string.Format("insert into  Fruits values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", textBox6.Text.Trim(), textBox1.Text.ToString(), Convert.ToDouble(textBox2.Text.ToString()),textBox7.Text, textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString());
                        SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                        com.ExecuteNonQuery();

                        MessageBox.Show("成功");
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

        private void goodsAdd_Load(object sender, EventArgs e)
        {

        }
    }
}