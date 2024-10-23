namespace Views
{
    partial class CustomerInfo_CreateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfo_CreateFrm));
            this.btnExist = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.btnCreateUpdate = new System.Windows.Forms.Button();
            this.comboCustomerGender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimeBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExist
            // 
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Location = new System.Drawing.Point(630, 12);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(32, 32);
            this.btnExist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExist.TabIndex = 0;
            this.btnExist.TabStop = false;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "MÃ KHÁCH HÀNG";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Enabled = false;
            this.txtCustomerId.Location = new System.Drawing.Point(61, 160);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(254, 30);
            this.txtCustomerId.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(365, 159);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(254, 30);
            this.txtCustomerName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "HỌ TÊN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "SỐ ĐIỆN THOẠI";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(61, 238);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(254, 30);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "DOANH SỐ";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(61, 394);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(192, 30);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "ĐỊA CHỈ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 28);
            this.label7.TabIndex = 4;
            this.label7.Text = "GIỚI TÍNH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 28);
            this.label8.TabIndex = 4;
            this.label8.Text = "HẠNG";
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(365, 394);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(254, 30);
            this.txtRank.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(61, 472);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(558, 132);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.Text = "";
            // 
            // btnCreateUpdate
            // 
            this.btnCreateUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(54)))));
            this.btnCreateUpdate.FlatAppearance.BorderSize = 0;
            this.btnCreateUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnCreateUpdate.Location = new System.Drawing.Point(154, 630);
            this.btnCreateUpdate.Name = "btnCreateUpdate";
            this.btnCreateUpdate.Size = new System.Drawing.Size(366, 65);
            this.btnCreateUpdate.TabIndex = 10;
            this.btnCreateUpdate.Text = "CẬP NHẬT";
            this.btnCreateUpdate.UseVisualStyleBackColor = false;
            this.btnCreateUpdate.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // comboCustomerGender
            // 
            this.comboCustomerGender.FormattingEnabled = true;
            this.comboCustomerGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboCustomerGender.Location = new System.Drawing.Point(365, 238);
            this.comboCustomerGender.Name = "comboCustomerGender";
            this.comboCustomerGender.Size = new System.Drawing.Size(254, 31);
            this.comboCustomerGender.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "NGÀY SINH";
            // 
            // dateTimeBirthDate
            // 
            this.dateTimeBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBirthDate.Location = new System.Drawing.Point(61, 316);
            this.dateTimeBirthDate.Name = "dateTimeBirthDate";
            this.dateTimeBirthDate.Size = new System.Drawing.Size(254, 30);
            this.dateTimeBirthDate.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 28);
            this.label10.TabIndex = 4;
            this.label10.Text = "EMAIL";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(365, 319);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 30);
            this.txtEmail.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(259, 392);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 28);
            this.label11.TabIndex = 14;
            this.label11.Text = "VNĐ";
            // 
            // CustomerInfo_CreateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(674, 737);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimeBirthDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboCustomerGender);
            this.Controls.Add(this.btnCreateUpdate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExist);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CustomerInfo_CreateFrm";
            this.Text = "CustomerInfoFrm";
            ((System.ComponentModel.ISupportInitialize)(this.btnExist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Button btnCreateUpdate;
        private System.Windows.Forms.ComboBox comboCustomerGender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimeBirthDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
    }
}