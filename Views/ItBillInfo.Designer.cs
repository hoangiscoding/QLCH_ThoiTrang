namespace Views
{
    partial class ItBillInfo
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.Label();
            this.txtProductSize = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtTotal);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.txtProductSize);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Controls.Add(this.txtProductId);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(920, 48);
            this.panel3.TabIndex = 3;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(709, 13);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(113, 23);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "THÀNH TIỀN";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoSize = true;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(588, 13);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(29, 23);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.Text = "SL";
            // 
            // txtProductSize
            // 
            this.txtProductSize.AutoSize = true;
            this.txtProductSize.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSize.Location = new System.Drawing.Point(406, 13);
            this.txtProductSize.Name = "txtProductSize";
            this.txtProductSize.Size = new System.Drawing.Size(44, 23);
            this.txtProductSize.TabIndex = 10;
            this.txtProductSize.Text = "SIZE";
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(167, 13);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(67, 23);
            this.txtProductName.TabIndex = 9;
            this.txtProductName.Text = "TÊN SP";
            // 
            // txtProductId
            // 
            this.txtProductId.AutoSize = true;
            this.txtProductId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(18, 13);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(63, 23);
            this.txtProductId.TabIndex = 8;
            this.txtProductId.Text = "MÃ SP";
            // 
            // ItBillInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(920, 48);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItBillInfo";
            this.Text = "ItProductInfo";
            this.Load += new System.EventHandler(this.ItBillInfo_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label txtQuantity;
        private System.Windows.Forms.Label txtProductSize;
        private System.Windows.Forms.Label txtProductName;
        private System.Windows.Forms.Label txtProductId;
    }
}