namespace QuanLyDaiHocGiaDinh
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnComback = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.laNotice = new System.Windows.Forms.Label();
            this.laTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelLogin);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(584, 375);
            this.splitContainerControl1.SplitterPosition = 169;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.btnComback);
            this.panelLogin.Controls.Add(this.btnLogout);
            this.panelLogin.Controls.Add(this.laNotice);
            this.panelLogin.Controls.Add(this.laTitle);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUserName);
            this.panelLogin.Controls.Add(this.btnExit);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(403, 375);
            this.panelLogin.TabIndex = 9;
            // 
            // btnComback
            // 
            this.btnComback.Location = new System.Drawing.Point(119, 114);
            this.btnComback.Name = "btnComback";
            this.btnComback.Size = new System.Drawing.Size(154, 32);
            this.btnComback.TabIndex = 0;
            this.btnComback.Text = "Quay lại";
            this.btnComback.Click += new System.EventHandler(this.btnComback_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(119, 161);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(154, 32);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // laNotice
            // 
            this.laNotice.AutoSize = true;
            this.laNotice.Location = new System.Drawing.Point(132, 100);
            this.laNotice.Name = "laNotice";
            this.laNotice.Size = new System.Drawing.Size(0, 13);
            this.laNotice.TabIndex = 8;
            // 
            // laTitle
            // 
            this.laTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTitle.Appearance.Options.UseFont = true;
            this.laTitle.Location = new System.Drawing.Point(148, 59);
            this.laTitle.Name = "laTitle";
            this.laTitle.Size = new System.Drawing.Size(104, 25);
            this.laTitle.TabIndex = 7;
            this.laTitle.Text = "Đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 173);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(201, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtPassword_EditValueChanging);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 126);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(201, 20);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtUserName_EditValueChanging);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(214, 221);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(98, 221);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 375);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl laTitle;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private System.Windows.Forms.Label laNotice;
        private System.Windows.Forms.Panel panelLogin;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.SimpleButton btnComback;
    }
}

