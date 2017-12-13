namespace cangku
{
    partial class loginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.btncancal = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.cbousertype = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.lblusertype = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancal
            // 
            this.btncancal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btncancal.Location = new System.Drawing.Point(182, 277);
            this.btncancal.Name = "btncancal";
            this.btncancal.Size = new System.Drawing.Size(84, 38);
            this.btncancal.TabIndex = 15;
            this.btncancal.Text = "取消";
            this.btncancal.UseVisualStyleBackColor = true;
            this.btncancal.Click += new System.EventHandler(this.btncancal_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnlogin.Location = new System.Drawing.Point(79, 277);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(79, 38);
            this.btnlogin.TabIndex = 14;
            this.btnlogin.Text = "登陆";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // cbousertype
            // 
            this.cbousertype.FormattingEnabled = true;
            this.cbousertype.Items.AddRange(new object[] {
            "管理员",
            "普通用户"});
            this.cbousertype.Location = new System.Drawing.Point(159, 207);
            this.cbousertype.Name = "cbousertype";
            this.cbousertype.Size = new System.Drawing.Size(132, 20);
            this.cbousertype.TabIndex = 13;
            this.cbousertype.SelectedIndexChanged += new System.EventHandler(this.cbousertype_SelectedIndexChanged);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(161, 141);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(130, 21);
            this.txtpassword.TabIndex = 12;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(160, 94);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(131, 21);
            this.txtuser.TabIndex = 11;
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.BackColor = System.Drawing.Color.Transparent;
            this.lblusertype.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblusertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblusertype.Location = new System.Drawing.Point(56, 208);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(85, 19);
            this.lblusertype.TabIndex = 10;
            this.lblusertype.Text = "用户类型";
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.BackColor = System.Drawing.Color.Transparent;
            this.lblpassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblpassword.Location = new System.Drawing.Point(56, 143);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(87, 19);
            this.lblpassword.TabIndex = 9;
            this.lblpassword.Text = "密    码";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.BackColor = System.Drawing.Color.Transparent;
            this.lbluser.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbluser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbluser.Location = new System.Drawing.Point(55, 94);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(86, 19);
            this.lbluser.TabIndex = 8;
            this.lbluser.Text = "用 户 名";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cangku.Properties.Resources.fruit4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(347, 375);
            this.ControlBox = false;
            this.Controls.Add(this.btncancal);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.cbousertype);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.lblusertype);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lbluser);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "loginForm";
            this.Text = "欢迎";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancal;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.ComboBox cbousertype;
    }
}

