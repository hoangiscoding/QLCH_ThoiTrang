namespace Views
{
    partial class ChangePasswordFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNewPasswordAgain = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.checkBoxShowOldPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxShowNewPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxShowNewPasswordAgain = new System.Windows.Forms.CheckBox();
            this.btnExist = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtOldPassword);
            this.panel1.Location = new System.Drawing.Point(61, 81);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panel1.Size = new System.Drawing.Size(654, 67);
            this.panel1.TabIndex = 8;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOldPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtOldPassword.Location = new System.Drawing.Point(30, 20);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(594, 32);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.Text = "MẬT KHẨU CŨ:";
            this.txtOldPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtOldPassword_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.txtNewPassword);
            this.panel2.Location = new System.Drawing.Point(61, 194);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panel2.Size = new System.Drawing.Size(654, 67);
            this.panel2.TabIndex = 8;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtNewPassword.Location = new System.Drawing.Point(30, 20);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(594, 32);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.Text = "MẬT KHẨU MỚI:";
            this.txtNewPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNewPassword_MouseClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.txtNewPasswordAgain);
            this.panel3.Location = new System.Drawing.Point(61, 307);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panel3.Size = new System.Drawing.Size(654, 67);
            this.panel3.TabIndex = 8;
            // 
            // txtNewPasswordAgain
            // 
            this.txtNewPasswordAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.txtNewPasswordAgain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPasswordAgain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewPasswordAgain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPasswordAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.txtNewPasswordAgain.Location = new System.Drawing.Point(30, 20);
            this.txtNewPasswordAgain.Name = "txtNewPasswordAgain";
            this.txtNewPasswordAgain.Size = new System.Drawing.Size(594, 32);
            this.txtNewPasswordAgain.TabIndex = 3;
            this.txtNewPasswordAgain.Text = "NHẬP LẠI MẬT KHẨU:";
            this.txtNewPasswordAgain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNewPasswordAgain_MouseClick);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(245)))), ((int)(((byte)(238)))));
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.Black;
            this.btnChangePassword.Location = new System.Drawing.Point(201, 430);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(366, 65);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "ĐỔI MẬT KHẨU";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // checkBoxShowOldPassword
            // 
            this.checkBoxShowOldPassword.AutoSize = true;
            this.checkBoxShowOldPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowOldPassword.ForeColor = System.Drawing.Color.Transparent;
            this.checkBoxShowOldPassword.Location = new System.Drawing.Point(520, 155);
            this.checkBoxShowOldPassword.Name = "checkBoxShowOldPassword";
            this.checkBoxShowOldPassword.Size = new System.Drawing.Size(234, 36);
            this.checkBoxShowOldPassword.TabIndex = 10;
            this.checkBoxShowOldPassword.Text = "HIỆN MẬT KHẨU";
            this.checkBoxShowOldPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowOldPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowOldPassword_CheckedChanged);
            // 
            // checkBoxShowNewPassword
            // 
            this.checkBoxShowNewPassword.AutoSize = true;
            this.checkBoxShowNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowNewPassword.ForeColor = System.Drawing.Color.Transparent;
            this.checkBoxShowNewPassword.Location = new System.Drawing.Point(520, 268);
            this.checkBoxShowNewPassword.Name = "checkBoxShowNewPassword";
            this.checkBoxShowNewPassword.Size = new System.Drawing.Size(234, 36);
            this.checkBoxShowNewPassword.TabIndex = 10;
            this.checkBoxShowNewPassword.Text = "HIỆN MẬT KHẨU";
            this.checkBoxShowNewPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowNewPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowNewPassword_CheckedChanged);
            // 
            // checkBoxShowNewPasswordAgain
            // 
            this.checkBoxShowNewPasswordAgain.AutoSize = true;
            this.checkBoxShowNewPasswordAgain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowNewPasswordAgain.ForeColor = System.Drawing.Color.Transparent;
            this.checkBoxShowNewPasswordAgain.Location = new System.Drawing.Point(520, 381);
            this.checkBoxShowNewPasswordAgain.Name = "checkBoxShowNewPasswordAgain";
            this.checkBoxShowNewPasswordAgain.Size = new System.Drawing.Size(234, 36);
            this.checkBoxShowNewPasswordAgain.TabIndex = 10;
            this.checkBoxShowNewPasswordAgain.Text = "HIỆN MẬT KHẨU";
            this.checkBoxShowNewPasswordAgain.UseVisualStyleBackColor = true;
            this.checkBoxShowNewPasswordAgain.CheckedChanged += new System.EventHandler(this.checkBoxShowNewPasswordAgain_CheckedChanged);
            // 
            // btnExist
            // 
            this.btnExist.FlatAppearance.BorderSize = 0;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Location = new System.Drawing.Point(732, 12);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(32, 32);
            this.btnExist.TabIndex = 10;
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // ChangePasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(776, 524);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.checkBoxShowNewPasswordAgain);
            this.Controls.Add(this.checkBoxShowNewPassword);
            this.Controls.Add(this.checkBoxShowOldPassword);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChangePasswordFrm";
            this.Text = "ChangePasswordFrm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNewPasswordAgain;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.CheckBox checkBoxShowOldPassword;
        private System.Windows.Forms.CheckBox checkBoxShowNewPassword;
        private System.Windows.Forms.CheckBox checkBoxShowNewPasswordAgain;
        private System.Windows.Forms.Button btnExist;
    }
}