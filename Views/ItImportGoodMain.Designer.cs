namespace Views
{
    partial class ItImportGoodMain
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
            this.txtDate = new System.Windows.Forms.Label();
            this.txtStaff = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtDate);
            this.panel4.Controls.Add(this.txtStaff);
            this.panel4.Controls.Add(this.txtId);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(770, 61);
            this.panel4.TabIndex = 23;
            this.panel4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseClick);
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtDate.Location = new System.Drawing.Point(548, 16);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(62, 28);
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "Ngày";
            // 
            // txtStaff
            // 
            this.txtStaff.AutoSize = true;
            this.txtStaff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtStaff.Location = new System.Drawing.Point(216, 16);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.Size = new System.Drawing.Size(109, 28);
            this.txtStaff.TabIndex = 1;
            this.txtStaff.Text = "Nhân viên";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtId.Location = new System.Drawing.Point(14, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(101, 28);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "Mã phiếu";
            // 
            // ItImportGoodMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 61);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItImportGoodMain";
            this.Text = "ItImportGoodMain";
            this.Load += new System.EventHandler(this.ItImportGoodMain_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtStaff;
        private System.Windows.Forms.Label txtId;
    }
}