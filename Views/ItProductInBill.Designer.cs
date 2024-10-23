namespace Views
{
    partial class ItProductInBill
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtProductPrice = new System.Windows.Forms.Label();
            this.txtProductQuantity = new System.Windows.Forms.Label();
            this.txtProductSize = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.Label();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.txtProductPrice);
            this.panel10.Controls.Add(this.txtProductQuantity);
            this.panel10.Controls.Add(this.txtProductSize);
            this.panel10.Controls.Add(this.txtProductName);
            this.panel10.Controls.Add(this.txtProductId);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(920, 48);
            this.panel10.TabIndex = 15;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.AutoSize = true;
            this.txtProductPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductPrice.Location = new System.Drawing.Point(709, 13);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(117, 23);
            this.txtProductPrice.TabIndex = 12;
            this.txtProductPrice.Text = "120.000 VNĐ";
            // 
            // txtProductQuantity
            // 
            this.txtProductQuantity.AutoSize = true;
            this.txtProductQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductQuantity.Location = new System.Drawing.Point(588, 13);
            this.txtProductQuantity.Name = "txtProductQuantity";
            this.txtProductQuantity.Size = new System.Drawing.Size(20, 23);
            this.txtProductQuantity.TabIndex = 11;
            this.txtProductQuantity.Text = "2";
            // 
            // txtProductSize
            // 
            this.txtProductSize.AutoSize = true;
            this.txtProductSize.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSize.Location = new System.Drawing.Point(406, 13);
            this.txtProductSize.Name = "txtProductSize";
            this.txtProductSize.Size = new System.Drawing.Size(19, 23);
            this.txtProductSize.TabIndex = 10;
            this.txtProductSize.Text = "L";
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(167, 13);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(71, 23);
            this.txtProductName.TabIndex = 9;
            this.txtProductName.Text = "Áo Polo";
            // 
            // txtProductId
            // 
            this.txtProductId.AutoSize = true;
            this.txtProductId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(18, 13);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(53, 23);
            this.txtProductId.TabIndex = 8;
            this.txtProductId.Text = "AK01";
            // 
            // ItProductInBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 48);
            this.Controls.Add(this.panel10);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItProductInBill";
            this.Text = "ItProductInBill";
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label txtProductPrice;
        private System.Windows.Forms.Label txtProductQuantity;
        private System.Windows.Forms.Label txtProductSize;
        private System.Windows.Forms.Label txtProductName;
        private System.Windows.Forms.Label txtProductId;
    }
}