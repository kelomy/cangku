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
    public partial class goodsModify : Form
    {
        public goodsModify()
        {
            InitializeComponent();
        }

        private void button1_click(object sender, EventArgs e)
        {
            try
            {
                dbhelper.connection.Open();
                string sql = string.Format("select * from Fruits where FID='{0}'", comboBox1.Text.Trim());
                SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())//存在对应项
                {
                    textBox2.Text = dr["FName"].ToString();
                    textBox3.Text = dr["FPrice"].ToString();
                    textBox4.Text = dr["FProvider1"].ToString();
                    textBox6.Text = dr["FProvider2"].ToString();
                    textBox5.Text = dr["FDescribe"].ToString();
                }
                else
                {
                    MessageBox.Show("对不起，没有该产品信息");
                }
            }
            catch
            {
                comboBox1.Text = "";
            }
            finally
            {
                dbhelper.connection.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    dbhelper.connection.Open();
                    string sql = string.Format("delete  from Fruits where FID='{0}'", comboBox1.Text.Trim());
                    SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("删除成功!");
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

        private void btnmodify_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定修改此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    dbhelper.connection.Open();
                    string sql = string.Format("update Fruits set FName='{0}',FPrice='{1}',FProvider1='{2}',FProvider2='{3}',FDescribe='{4}'where FID='{5}'", textBox2.Text.Trim(), Convert.ToDouble(textBox3.Text.Trim()), textBox4.Text.Trim(), textBox6.Text.Trim(), textBox5.Text.Trim(), comboBox1.Text.Trim());
                    SqlCommand com = new SqlCommand(sql, dbhelper.connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("修改成功");
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

        private void goodsModify_Load(object sender, EventArgs e)
        {
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
        }

       

       
    }
}