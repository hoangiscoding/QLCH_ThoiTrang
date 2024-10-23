namespace Views
{
    partial class ItBillInfoMain
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDiscountedAmount = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.Label();
            this.txtBillId = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtDiscountedAmount);
            this.panel4.Controls.Add(this.txtDate);
            this.panel4.Controls.Add(this.txtCustomerName);
            this.panel4.Controls.Add(this.txtBillId);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 61);
            this.panel4.TabIndex = 22;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // txtDiscountedAmount
            // 
            this.txtDiscountedAmount.AutoSize = true;
            this.txtDiscountedAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountedAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtDiscountedAmount.Location = new System.Drawing.Point(589, 16);
            this.txtDiscountedAmount.Name = "txtDiscountedAmount";
            this.txtDiscountedAmount.Size = new System.Drawing.Size(71, 28);
            this.txtDiscountedAmount.TabIndex = 3;
            this.txtDiscountedAmount.Text = "Trị giá";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtDate.Location = new System.Drawing.Point(380, 16);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(62, 28);
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "Ngày";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AutoSize = true;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtCustomerName.Location = new System.Drawing.Point(102, 16);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(123, 28);
            this.txtCustomerName.TabIndex = 1;
            this.txtCustomerName.Text = "Khách hàng";
            // 
            // txtBillId
            // 
            this.txtBillId.AutoSize = true;
            this.txtBillId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtBillId.Location = new System.Drawing.Point(14, 16);
            this.txtBillId.Name = "txtBillId";
            this.txtBillId.Size = new System.Drawing.Size(71, 28);
            this.txtBillId.TabIndex = 0;
            this.txtBillId.Text = "Số HĐ";
            // 
            // ItBillInfoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 61);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItBillInfoMain";
            this.Text = "ItBillInfoMain";
            this.Load += new System.EventHandler(this.ItBillInfoMain_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label txtDiscountedAmount;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtCustomerName;
        private System.Windows.Forms.Label txtBillId;
    }
}