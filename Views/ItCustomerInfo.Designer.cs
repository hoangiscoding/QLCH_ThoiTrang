namespace Views
{
    partial class ItCustomerInfo
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
            this.panelPerson = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.panelPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPerson
            // 
            this.panelPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.panelPerson.Controls.Add(this.txtAddress);
            this.panelPerson.Controls.Add(this.txtPhone);
            this.panelPerson.Controls.Add(this.txtName);
            this.panelPerson.Controls.Add(this.txtId);
            this.panelPerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelPerson.Location = new System.Drawing.Point(0, 0);
            this.panelPerson.Name = "panelPerson";
            this.panelPerson.Size = new System.Drawing.Size(770, 61);
            this.panelPerson.TabIndex = 25;
            this.panelPerson.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPerson_MouseClick);
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(512, 16);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(209, 32);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "1 Trần Hưng Đạo";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(323, 16);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(154, 32);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.Text = "0792352702";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(90, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 32);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Nguyễn Văn A";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(11, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(28, 32);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "1";
            // 
            // ItCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(772, 63);
            this.Controls.Add(this.panelPerson);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItCustomerInfo";
            this.Text = "ItCustomerInfo";
            this.Load += new System.EventHandler(this.ItCustomerInfo_Load);
            this.panelPerson.ResumeLayout(false);
            this.panelPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPerson;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.Label txtPhone;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtId;
    }
}