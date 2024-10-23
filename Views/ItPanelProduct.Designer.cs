namespace Views
{
    partial class ItPanelProduct
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
            this.panelProduct = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProductCreate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProductFind = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboProductFind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProduct.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProduct
            // 
            this.panelProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.panelProduct.Controls.Add(this.panel5);
            this.panelProduct.Controls.Add(this.flowPanelProduct);
            this.panelProduct.Controls.Add(this.btnProductCreate);
            this.panelProduct.Controls.Add(this.panel3);
            this.panelProduct.Controls.Add(this.panel4);
            this.panelProduct.Controls.Add(this.label3);
            this.panelProduct.Location = new System.Drawing.Point(0, 0);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(814, 703);
            this.panelProduct.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.comboFilter);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(12, 102);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(189, 73);
            this.panel5.TabIndex = 21;
            // 
            // comboFilter
            // 
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Items.AddRange(new object[] {
            "Sắp xếp theo mã SP tăng dần",
            "Sắp xếp theo mã SP giảm dần",
            "Sắp xếp theo giá tăng dần",
            "Sắp xếp theo giá giảm dần",
            "Sắp xếp theo tên SP A-Z"});
            this.comboFilter.Location = new System.Drawing.Point(6, 31);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(180, 36);
            this.comboFilter.TabIndex = 1;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bộ lọc";
            // 
            // flowPanelProduct
            // 
            this.flowPanelProduct.AutoScroll = true;
            this.flowPanelProduct.Location = new System.Drawing.Point(0, 181);
            this.flowPanelProduct.Name = "flowPanelProduct";
            this.flowPanelProduct.Size = new System.Drawing.Size(810, 519);
            this.flowPanelProduct.TabIndex = 23;
            // 
            // btnProductCreate
            // 
            this.btnProductCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.btnProductCreate.FlatAppearance.BorderSize = 0;
            this.btnProductCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnProductCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductCreate.Location = new System.Drawing.Point(645, 102);
            this.btnProductCreate.Name = "btnProductCreate";
            this.btnProductCreate.Size = new System.Drawing.Size(145, 73);
            this.btnProductCreate.TabIndex = 22;
            this.btnProductCreate.Text = "TẠO";
            this.btnProductCreate.UseVisualStyleBackColor = false;
            this.btnProductCreate.Click += new System.EventHandler(this.btnProductFind_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtProductFind);
            this.panel3.Location = new System.Drawing.Point(384, 102);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20, 20, 10, 10);
            this.panel3.Size = new System.Drawing.Size(255, 73);
            this.panel3.TabIndex = 21;
            // 
            // txtProductFind
            // 
            this.txtProductFind.BackColor = System.Drawing.Color.White;
            this.txtProductFind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductFind.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductFind.ForeColor = System.Drawing.Color.Gray;
            this.txtProductFind.Location = new System.Drawing.Point(20, 20);
            this.txtProductFind.Name = "txtProductFind";
            this.txtProductFind.Size = new System.Drawing.Size(225, 37);
            this.txtProductFind.TabIndex = 5;
            this.txtProductFind.Text = "Tìm kiếm:";
            this.txtProductFind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProductFind_MouseClick);
            this.txtProductFind.TextChanged += new System.EventHandler(this.txtProductFind_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.comboProductFind);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(208, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 73);
            this.panel4.TabIndex = 20;
            // 
            // comboProductFind
            // 
            this.comboProductFind.FormattingEnabled = true;
            this.comboProductFind.Items.AddRange(new object[] {
            "Theo mã SP",
            "Theo tên SP"});
            this.comboProductFind.Location = new System.Drawing.Point(8, 31);
            this.comboProductFind.Name = "comboProductFind";
            this.comboProductFind.Size = new System.Drawing.Size(159, 36);
            this.comboProductFind.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tìm kiếm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(4, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "SẢN PHẨM";
            // 
            // ItPanelProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 785);
            this.Controls.Add(this.panelProduct);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItPanelProduct";
            this.Text = "ItPanelProduct";
            this.Load += new System.EventHandler(this.ItPanelProduct_Load);
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowPanelProduct;
        private System.Windows.Forms.Button btnProductCreate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProductFind;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboProductFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}