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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            bool isvaliuser = false;
            //dbhelper.LoginId = txtuser.Text;
            if (validateinput())
            {
                isvaliuser = validateuser(cbousertype.Text, txtuser.Text, txtpassword.Text);
                if (isvaliuser)
                {
                    dbhelper.LoginId = txtuser.Text;
                    //dbhelper.LoginId = cbousertype.Text;
                    showuserfrom();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("用户名或密码不存在或权限不对", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool validateinput()
        {
            if (txtuser.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Focus();
                return false;
            }
            else if (txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpassword.Focus();
                return false;
            }
            else if (cbousertype.Text.Trim() == "")
            {
                MessageBox.Show("输入登录类型", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbousertype.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btncancal_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }//退出
        public void showuserfrom()
        {
            switch (cbousertype.Text)
            {
                case "管理员":
                    Form fm = new mainForm();
                    fm.Show();
                    break;
                default:
                    mainForm fm1 = new mainForm();
                    fm1.人员信息维护ToolStripMenuItem.Visible = false;
                    fm1.Show();
                    break;
            }

        }//窗口方法



    //验证是否为空
    public bool validateuser(string logintype, string loginid, string loginpwd)
    {
            string tt = MD5Encrypt.MD5Manager.Md5Encrypt(loginpwd);
        int count = 0;
        bool isvaliduser = false;
            //MessageBox.Show("[" + loginid + "," + tt + "," + cbousertype.Text + "]");
            string sql = string.Format("select count(*) from Users where UID='{0}' and UPassword='{1}'and UPower='{2}'", loginid, loginpwd, cbousertype.Text);
            try
        {
            SqlCommand command = new SqlCommand(sql, dbhelper.connection);
            dbhelper.connection.Open();
            
               
            count =(Int32)command.ExecuteScalar();
            if (count == 1)
            {
                isvaliduser = true;
            }
            else
            {
                isvaliduser = false;
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

        return isvaliduser;
    }

        private void cbousertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //账号密码是否正确
    }
 }
  


