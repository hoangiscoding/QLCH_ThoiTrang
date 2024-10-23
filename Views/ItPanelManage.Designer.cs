namespace Views
{
    partial class ItPanelManage
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
            this.flowPanelStaff = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStaffCreate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtStaffFind = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboStaffFind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProduct.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProduct
            // 
            this.panelProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.panelProduct.Controls.Add(this.flowPanelStaff);
            this.panelProduct.Controls.Add(this.btnStaffCreate);
            this.panelProduct.Controls.Add(this.panel3);
            this.panelProduct.Controls.Add(this.panel4);
            this.panelProduct.Controls.Add(this.label3);
            this.panelProduct.Location = new System.Drawing.Point(0, 0);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(810, 789);
            this.panelProduct.TabIndex = 25;
            // 
            // flowPanelStaff
            // 
            this.flowPanelStaff.AutoScroll = true;
            this.flowPanelStaff.Location = new System.Drawing.Point(4, 206);
            this.flowPanelStaff.Name = "flowPanelStaff";
            this.flowPanelStaff.Size = new System.Drawing.Size(803, 568);
            this.flowPanelStaff.TabIndex = 23;
            // 
            // btnStaffCreate
            // 
            this.btnStaffCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.btnStaffCreate.FlatAppearance.BorderSize = 0;
            this.btnStaffCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnStaffCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaffCreate.Location = new System.Drawing.Point(645, 102);
            this.btnStaffCreate.Name = "btnStaffCreate";
            this.btnStaffCreate.Size = new System.Drawing.Size(162, 73);
            this.btnStaffCreate.TabIndex = 22;
            this.btnStaffCreate.Text = "TẠO";
            this.btnStaffCreate.UseVisualStyleBackColor = false;
            this.btnStaffCreate.Click += new System.EventHandler(this.btnStaffCreate_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtStaffFind);
            this.panel3.Location = new System.Drawing.Point(279, 102);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20, 20, 10, 10);
            this.panel3.Size = new System.Drawing.Size(360, 73);
            this.panel3.TabIndex = 21;
            // 
            // txtStaffFind
            // 
            this.txtStaffFind.BackColor = System.Drawing.Color.White;
            this.txtStaffFind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStaffFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStaffFind.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffFind.ForeColor = System.Drawing.Color.Gray;
            this.txtStaffFind.Location = new System.Drawing.Point(20, 20);
            this.txtStaffFind.Name = "txtStaffFind";
            this.txtStaffFind.Size = new System.Drawing.Size(330, 37);
            this.txtStaffFind.TabIndex = 5;
            this.txtStaffFind.Text = "Tìm kiếm:";
            this.txtStaffFind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStaffFind_MouseClick);
            this.txtStaffFind.TextChanged += new System.EventHandler(this.txtStaffFind_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.comboStaffFind);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(261, 73);
            this.panel4.TabIndex = 20;
            // 
            // comboStaffFind
            // 
            this.comboStaffFind.FormattingEnabled = true;
            this.comboStaffFind.Items.AddRange(new object[] {
            "Theo tên",
            "Theo năm sinh",
            "Theo giới tính",
            "Theo username",
            "Theo chức vụ"});
            this.comboStaffFind.Location = new System.Drawing.Point(6, 31);
            this.comboStaffFind.Name = "comboStaffFind";
            this.comboStaffFind.Size = new System.Drawing.Size(252, 36);
            this.comboStaffFind.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 3);
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
            this.label3.Size = new System.Drawing.Size(433, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // ItPanelManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 790);
            this.Controls.Add(this.panelProduct);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItPanelManage";
            this.Text = "ItPanelManage";
            this.Load += new System.EventHandler(this.ItPanelManage_Load);
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.FlowLayoutPanel flowPanelStaff;
        private System.Windows.Forms.Button btnStaffCreate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtStaffFind;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboStaffFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}