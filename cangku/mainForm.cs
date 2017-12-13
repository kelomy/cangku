using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cangku
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void 货品信息列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new goodsManage();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form fm = new loginForm();
            fm.Show();
        }

        private void 货品信息新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new goodsAdd();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 个人密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new passwordmodify();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 权限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new userpower();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 添加新成员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new useradd();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 货品信息删改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new goodsModify();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 货物进出添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new goodsReserve();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 添加存放规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new StoreRegularAdd();
            fm.Show();
        }

        private void 存放规则浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new StoreRegularManage();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 仓库信息浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new WarehouseManage();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 仓库信息添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new WarehouseAdd();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 货物进出浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new RecordsList();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fm = new OrderDetail();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
          passwordmodify fm = new passwordmodify();
          fm.MdiParent = this;
          
          fm.textBox1.Text = dbhelper.LoginId;
          fm.textBox1.ReadOnly = true;
           fm.Show();
        }

        private void 人员信息浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new usermanage();
            fm.MdiParent = this;
            
            fm.Show();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("制作人：201412300064");

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void 人员信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}