namespace QuanLyDaiHocGiaDinh.Views
{
    partial class AdminUpdatePosition
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
            this.components = new System.ComponentModel.Container();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtChucVu = new DevExpress.XtraEditors.TextEdit();
            this.lblSuaChucVu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhongBan = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.giaDinhUniversityDataSet = new QuanLyDaiHocGiaDinh.Model.GiaDinhUniversityDataSet();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentsTableAdapter = new QuanLyDaiHocGiaDinh.Model.GiaDinhUniversityDataSetTableAdapters.DepartmentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.txtChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaDinhUniversityDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(366, 227);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(94, 29);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Cancel";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(126, 227);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(94, 29);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "OK";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(243, 107);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtChucVu.Properties.Appearance.Options.UseFont = true;
            this.txtChucVu.Size = new System.Drawing.Size(192, 28);
            this.txtChucVu.TabIndex = 12;
            // 
            // lblSuaChucVu
            // 
            this.lblSuaChucVu.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSuaChucVu.Appearance.Options.UseFont = true;
            this.lblSuaChucVu.Location = new System.Drawing.Point(107, 110);
            this.lblSuaChucVu.Name = "lblSuaChucVu";
            this.lblSuaChucVu.Size = new System.Drawing.Size(65, 21);
            this.lblSuaChucVu.TabIndex = 11;
            this.lblSuaChucVu.Text = "Chức vụ:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(203, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 29);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Sửa chức vụ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(107, 165);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(125, 21);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Chọn phòng ban:";
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.Location = new System.Drawing.Point(243, 162);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPhongBan.Properties.Appearance.Options.UseFont = true;
            this.txtPhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPhongBan.Properties.DataSource = this.departmentsBindingSource;
            this.txtPhongBan.Properties.DisplayMember = "DepartmentName";
            this.txtPhongBan.Properties.ValueMember = "DepartmentId";
            this.txtPhongBan.Size = new System.Drawing.Size(192, 28);
            this.txtPhongBan.TabIndex = 16;
            this.txtPhongBan.Popup += new System.EventHandler(this.txtPhongBan_Popup);
            // 
            // giaDinhUniversityDataSet
            // 
            this.giaDinhUniversityDataSet.DataSetName = "GiaDinhUniversityDataSet";
            this.giaDinhUniversityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "Departments";
            this.departmentsBindingSource.DataSource = this.giaDinhUniversityDataSet;
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // AdminUpdatePosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 299);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPhongBan);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.lblSuaChucVu);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminUpdatePosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminUpdatePosition";
            this.Load += new System.EventHandler(this.AdminUpdatePosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaDinhUniversityDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.TextEdit txtChucVu;
        private DevExpress.XtraEditors.LabelControl lblSuaChucVu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit txtPhongBan;
        private Model.GiaDinhUniversityDataSet giaDinhUniversityDataSet;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private Model.GiaDinhUniversityDataSetTableAdapters.DepartmentsTableAdapter departmentsTableAdapter;
    }
}