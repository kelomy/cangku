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
    public partial class goodsReserve : Form
    {
        public goodsReserve()
        {
            InitializeComponent();
        }

        private void goodsReserve_Load(object sender, EventArgs e)
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
            radioButton1.Checked = true;
            comboBox1.Text = "";
            comboBox2.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            dbhelper.connection.Open();
            string sql = string.Format("select * from Store where SFID='{0}'and SWID='{1}'", comboBox1.Text, comboBox2.Text);
            SqlCommand com = new SqlCommand(sql, dbhelper.connection);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[4].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = textBox2.Text;
                textBox5.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox2.Text));
            }
            else
            {
                
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("没有符合条件的信息");
            }
            dbhelper.connection.Close();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                dbhelper.connection.Open();
                DateTime dt = DateTime.Now;
               string gid =comboBox1.Text;
                string wid = comboBox2.Text;

                bool type = true;
                string sqll;  
                
                 string sqlll;
                if(textBox6.Text!=""&&textBox7.Text!="")
                {
                 if (radioButton1.Checked == true&&Convert.ToInt32(textBox5.Text)>Convert.ToInt32(textBox6.Text))
                 {
                     sqlll = string.Format("update Store set SQuantity=SQuantity+'{0}' where SFID='{1}'and SWID='{2}'", Convert.ToDouble(textBox6.Text.Trim()), comboBox1.Text, comboBox2.Text);
                      sqll = string.Format("insert into Records (RFID,RWID,RQuantity,Rtype,RManager,RHandler,RDate) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", gid, wid, Convert.ToDouble(textBox6.Text.Trim()), type, dbhelper.LoginId, textBox7.Text, dt);
                     SqlCommand com = new SqlCommand(sqll, dbhelper.connection);
                     com.ExecuteNonQuery();
                     com.CommandText = sqlll;
                     com.ExecuteNonQuery();
                     MessageBox.Show("添加成功", "提示");
                 }
                 else if (radioButton2.Checked == true && Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox6.Text) )
                 {
                     type = false;
                     sqlll = string.Format("update Store set SQuantity=SQuantity-'{0}' where SFID='{1}'and SWID='{2}'", Convert.ToDouble(textBox6.Text.Trim()), comboBox1.Text, comboBox2.Text);
                    sqll = string.Format("insert into Records (RFID,RWID,RQuantity,Rtype,RManager,RHandler,RDate) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", gid, wid, Convert.ToDouble(textBox6.Text.Trim()), type, dbhelper.LoginId, textBox7.Text, dt);
                     SqlCommand com = new SqlCommand(sqll, dbhelper.connection);
                     com.ExecuteNonQuery();
                     com.CommandText = sqlll;
                     com.ExecuteNonQuery();
                     MessageBox.Show("添加成功", "提示");
                 }
                }
                 else
                 {
                     MessageBox.Show("录入信息不符合要求!");
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