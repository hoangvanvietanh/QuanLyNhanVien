namespace QuanLyDaiHocGiaDinh.Views
{
    partial class HomeForgotPassword
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
            this.laTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtEmailForgotPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.btnTiepTuc = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblMaTuEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtMatuEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblMatKhauMoi = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.lblNhapLaiMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.txtNhapLaiMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.btnTiepTuc1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailForgotPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatuEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // laTitle
            // 
            this.laTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTitle.Appearance.Options.UseFont = true;
            this.laTitle.Location = new System.Drawing.Point(68, 22);
            this.laTitle.Name = "laTitle";
            this.laTitle.Size = new System.Drawing.Size(195, 25);
            this.laTitle.TabIndex = 8;
            this.laTitle.Text = "Khôi phục mật khẩu ";
            // 
            // txtEmailForgotPassword
            // 
            this.txtEmailForgotPassword.Location = new System.Drawing.Point(68, 96);
            this.txtEmailForgotPassword.Name = "txtEmailForgotPassword";
            this.txtEmailForgotPassword.Size = new System.Drawing.Size(227, 20);
            this.txtEmailForgotPassword.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(28, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email : ";
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Location = new System.Drawing.Point(68, 206);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(75, 23);
            this.btnTiepTuc.TabIndex = 11;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(188, 206);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(65, 65);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(158, 13);
            this.lblThongBao.TabIndex = 13;
            this.lblThongBao.Text = "Nhập Email , và click \" Tiếp tục \"";
            // 
            // lblMaTuEmail
            // 
            this.lblMaTuEmail.Location = new System.Drawing.Point(28, 143);
            this.lblMaTuEmail.Name = "lblMaTuEmail";
            this.lblMaTuEmail.Size = new System.Drawing.Size(65, 13);
            this.lblMaTuEmail.TabIndex = 15;
            this.lblMaTuEmail.Text = "Mã từ Email : ";
            // 
            // txtMatuEmail
            // 
            this.txtMatuEmail.EditValue = "";
            this.txtMatuEmail.Enabled = false;
            this.txtMatuEmail.Location = new System.Drawing.Point(113, 140);
            this.txtMatuEmail.Name = "txtMatuEmail";
            this.txtMatuEmail.Size = new System.Drawing.Size(185, 20);
            this.txtMatuEmail.TabIndex = 14;
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.Location = new System.Drawing.Point(28, 99);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(70, 13);
            this.lblMatKhauMoi.TabIndex = 17;
            this.lblMatKhauMoi.Text = "Mật khẩu mới :";
            this.lblMatKhauMoi.Visible = false;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(132, 96);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(163, 20);
            this.txtMatKhauMoi.TabIndex = 16;
            this.txtMatKhauMoi.Visible = false;
            // 
            // lblNhapLaiMatKhau
            // 
            this.lblNhapLaiMatKhau.Location = new System.Drawing.Point(28, 145);
            this.lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            this.lblNhapLaiMatKhau.Size = new System.Drawing.Size(95, 13);
            this.lblNhapLaiMatKhau.TabIndex = 19;
            this.lblNhapLaiMatKhau.Text = "Nhập lại mật khẩu : ";
            this.lblNhapLaiMatKhau.Visible = false;
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(132, 142);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(166, 20);
            this.txtNhapLaiMatKhau.TabIndex = 18;
            this.txtNhapLaiMatKhau.Visible = false;
            // 
            // btnTiepTuc1
            // 
            this.btnTiepTuc1.Location = new System.Drawing.Point(68, 206);
            this.btnTiepTuc1.Name = "btnTiepTuc1";
            this.btnTiepTuc1.Size = new System.Drawing.Size(75, 23);
            this.btnTiepTuc1.TabIndex = 20;
            this.btnTiepTuc1.Text = "Tiếp tục";
            this.btnTiepTuc1.Visible = false;
            this.btnTiepTuc1.Click += new System.EventHandler(this.btnTiepTuc1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // HomeForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 266);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTiepTuc1);
            this.Controls.Add(this.lblNhapLaiMatKhau);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblMaTuEmail);
            this.Controls.Add(this.txtMatuEmail);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmailForgotPassword);
            this.Controls.Add(this.laTitle);
            this.Name = "HomeForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForgotPassword";
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailForgotPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatuEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl laTitle;
        private DevExpress.XtraEditors.TextEdit txtEmailForgotPassword;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.SimpleButton btnTiepTuc;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.Label lblThongBao;
        private DevExpress.XtraEditors.LabelControl lblMaTuEmail;
        private DevExpress.XtraEditors.TextEdit txtMatuEmail;
        private DevExpress.XtraEditors.LabelControl lblMatKhauMoi;
        private DevExpress.XtraEditors.TextEdit txtMatKhauMoi;
        private DevExpress.XtraEditors.LabelControl lblNhapLaiMatKhau;
        private DevExpress.XtraEditors.TextEdit txtNhapLaiMatKhau;
        private DevExpress.XtraEditors.SimpleButton btnTiepTuc1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}