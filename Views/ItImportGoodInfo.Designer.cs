﻿namespace Views
{
    partial class ItImportGoodInfo
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
            this.panelImportGood = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.Label();
            this.txtProductSize = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.Label();
            this.panelImportGood.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelImportGood
            // 
            this.panelImportGood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.panelImportGood.Controls.Add(this.txtTotal);
            this.panelImportGood.Controls.Add(this.txtQuantity);
            this.panelImportGood.Controls.Add(this.txtProductSize);
            this.panelImportGood.Controls.Add(this.txtProductName);
            this.panelImportGood.Controls.Add(this.txtProductId);
            this.panelImportGood.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelImportGood.Location = new System.Drawing.Point(0, 0);
            this.panelImportGood.Name = "panelImportGood";
            this.panelImportGood.Size = new System.Drawing.Size(917, 48);
            this.panelImportGood.TabIndex = 25;
            this.panelImportGood.Click += new System.EventHandler(this.panelImportGood_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(706, 13);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(119, 30);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.Text = "Thành tiền";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoSize = true;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.White;
            this.txtQuantity.Location = new System.Drawing.Point(580, 13);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(103, 30);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "Số lượng";
            // 
            // txtProductSize
            // 
            this.txtProductSize.AutoSize = true;
            this.txtProductSize.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSize.ForeColor = System.Drawing.Color.White;
            this.txtProductSize.Location = new System.Drawing.Point(403, 13);
            this.txtProductSize.Name = "txtProductSize";
            this.txtProductSize.Size = new System.Drawing.Size(52, 30);
            this.txtProductSize.TabIndex = 2;
            this.txtProductSize.Text = "Size";
            // 
            // txtProductName
            // 
            this.txtProductName.AutoSize = true;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.White;
            this.txtProductName.Location = new System.Drawing.Point(164, 13);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(148, 30);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.Text = "Tên sản phẩm";
            // 
            // txtProductId
            // 
            this.txtProductId.AutoSize = true;
            this.txtProductId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.ForeColor = System.Drawing.Color.White;
            this.txtProductId.Location = new System.Drawing.Point(20, 13);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(75, 30);
            this.txtProductId.TabIndex = 0;
            this.txtProductId.Text = "Mã SP";
            // 
            // ItImportGoodInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(920, 50);
            this.Controls.Add(this.panelImportGood);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItImportGoodInfo";
            this.Text = "ItImportGoodInfo";
            this.panelImportGood.ResumeLayout(false);
            this.panelImportGood.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImportGood;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label txtQuantity;
        private System.Windows.Forms.Label txtProductSize;
        private System.Windows.Forms.Label txtProductName;
        private System.Windows.Forms.Label txtProductId;
    }
}