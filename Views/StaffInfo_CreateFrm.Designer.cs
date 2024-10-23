namespace Views
{
    partial class StaffInfo_CreateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffInfo_CreateFrm));
            this.dateTimeStaffBirthDate = new System.Windows.Forms.DateTimePicker();
            this.comboStaffGender = new System.Windows.Forms.ComboBox();
            this.btnCreateUpdate = new System.Windows.Forms.Button();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStaffPhone = new System.Windows.Forms.TextBox();
            this.txtStaffUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExist = new System.Windows.Forms.PictureBox();
            this.txtStaffAdress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboStaffRole = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtStaffEmail = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExist)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeStaffBirthDate
            // 
            this.dateTimeStaffBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimeStaffBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStaffBirthDate.Location = new System.Drawing.Point(61, 345);
            this.dateTimeStaffBirthDate.Name = "dateTimeStaffBirthDate";
            this.dateTimeStaffBirthDate.Size = new System.Drawing.Size(254, 30);
            this.dateTimeStaffBirthDate.TabIndex = 63;
            // 
            // comboStaffGender
            // 
            this.comboStaffGender.FormattingEnabled = true;
            this.comboStaffGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboStaffGender.Location = new System.Drawing.Point(365, 251);
            this.comboStaffGender.Name = "comboStaffGender";
            this.comboStaffGender.Size = new System.Drawing.Size(254, 31);
            this.comboStaffGender.TabIndex = 62;
            // 
            // btnCreateUpdate
            // 
            this.btnCreateUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(54)))));
            this.btnCreateUpdate.FlatAppearance.BorderSize = 0;
            this.btnCreateUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnCreateUpdate.Location = new System.Drawing.Point(68, 598);
            this.btnCreateUpdate.Name = "btnCreateUpdate";
            this.btnCreateUpdate.Size = new System.Drawing.Size(234, 57);
            this.btnCreateUpdate.TabIndex = 61;
            this.btnCreateUpdate.Text = "CẬP NHẬT";
            this.btnCreateUpdate.UseVisualStyleBackColor = false;
            this.btnCreateUpdate.Click += new System.EventHandler(this.btnCreateUpdate_Click);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(365, 157);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(254, 30);
            this.txtStaffName.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 28);
            this.label7.TabIndex = 55;
            this.label7.Text = "GIỚI TÍNH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 57;
            this.label3.Text = "HỌ TÊN";
            // 
            // txtStaffPhone
            // 
            this.txtStaffPhone.Location = new System.Drawing.Point(61, 251);
            this.txtStaffPhone.Name = "txtStaffPhone";
            this.txtStaffPhone.Size = new System.Drawing.Size(254, 30);
            this.txtStaffPhone.TabIndex = 54;
            // 
            // txtStaffUsername
            // 
            this.txtStaffUsername.Location = new System.Drawing.Point(61, 157);
            this.txtStaffUsername.Name = "txtStaffUsername";
            this.txtStaffUsername.Size = new System.Drawing.Size(254, 30);
            this.txtStaffUsername.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 28);
            this.label6.TabIndex = 52;
            this.label6.Text = "ĐỊA CHỈ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 28);
            this.label5.TabIndex = 51;
            this.label5.Text = "NGÀY SINH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 28);
            this.label4.TabIndex = 50;
            this.label4.Text = "SỐ ĐIỆN THOẠI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 28);
            this.label2.TabIndex = 49;
            this.label2.Text = "TÊN ĐĂNG NHẬP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 45);
            this.label1.TabIndex = 48;
            this.label1.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // btnExist
            // 
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Location = new System.Drawing.Point(608, 27);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(32, 32);
            this.btnExist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExist.TabIndex = 47;
            this.btnExist.TabStop = false;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // txtStaffAdress
            // 
            this.txtStaffAdress.Location = new System.Drawing.Point(61, 439);
            this.txtStaffAdress.Name = "txtStaffAdress";
            this.txtStaffAdress.Size = new System.Drawing.Size(558, 30);
            this.txtStaffAdress.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(360, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 28);
            this.label9.TabIndex = 65;
            this.label9.Text = "CHỨC VỤ";
            // 
            // comboStaffRole
            // 
            this.comboStaffRole.FormattingEnabled = true;
            this.comboStaffRole.Items.AddRange(new object[] {
            "NHÂN VIÊN",
            "QUẢN LÝ"});
            this.comboStaffRole.Location = new System.Drawing.Point(365, 348);
            this.comboStaffRole.Name = "comboStaffRole";
            this.comboStaffRole.Size = new System.Drawing.Size(254, 31);
            this.comboStaffRole.TabIndex = 66;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(54)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnDelete.Location = new System.Drawing.Point(372, 598);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(234, 57);
            this.btnDelete.TabIndex = 67;
            this.btnDelete.Text = "XOÁ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(54)))));
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnResetPassword.Location = new System.Drawing.Point(200, 675);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(275, 57);
            this.btnResetPassword.TabIndex = 68;
            this.btnResetPassword.Text = "LẤY LẠI MẬT KHẨU";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // txtStaffEmail
            // 
            this.txtStaffEmail.Location = new System.Drawing.Point(61, 533);
            this.txtStaffEmail.Name = "txtStaffEmail";
            this.txtStaffEmail.Size = new System.Drawing.Size(558, 30);
            this.txtStaffEmail.TabIndex = 70;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(56, 487);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(72, 28);
            this.txtEmail.TabIndex = 69;
            this.txtEmail.Text = "EMAIL";
            // 
            // StaffInfo_CreateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 737);
            this.Controls.Add(this.txtStaffEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.comboStaffRole);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStaffAdress);
            this.Controls.Add(this.dateTimeStaffBirthDate);
            this.Controls.Add(this.comboStaffGender);
            this.Controls.Add(this.btnCreateUpdate);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStaffPhone);
            this.Controls.Add(this.txtStaffUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExist);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StaffInfo_CreateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffInfo_CreateFrm";
            ((System.ComponentModel.ISupportInitialize)(this.btnExist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeStaffBirthDate;
        private System.Windows.Forms.ComboBox comboStaffGender;
        private System.Windows.Forms.Button btnCreateUpdate;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStaffPhone;
        private System.Windows.Forms.TextBox txtStaffUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnExist;
        private System.Windows.Forms.TextBox txtStaffAdress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboStaffRole;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox txtStaffEmail;
        private System.Windows.Forms.Label txtEmail;
    }
}