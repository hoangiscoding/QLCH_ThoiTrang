namespace Views
{
    partial class SelectImageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectImageFrm));
            this.pictureMan = new System.Windows.Forms.PictureBox();
            this.pictureWoman = new System.Windows.Forms.PictureBox();
            this.btnAvatar1 = new System.Windows.Forms.Button();
            this.btnAvatar2 = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWoman)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureMan
            // 
            this.pictureMan.Image = ((System.Drawing.Image)(resources.GetObject("pictureMan.Image")));
            this.pictureMan.Location = new System.Drawing.Point(100, 89);
            this.pictureMan.Name = "pictureMan";
            this.pictureMan.Size = new System.Drawing.Size(270, 275);
            this.pictureMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMan.TabIndex = 0;
            this.pictureMan.TabStop = false;
            // 
            // pictureWoman
            // 
            this.pictureWoman.Image = ((System.Drawing.Image)(resources.GetObject("pictureWoman.Image")));
            this.pictureWoman.Location = new System.Drawing.Point(566, 89);
            this.pictureWoman.Name = "pictureWoman";
            this.pictureWoman.Size = new System.Drawing.Size(270, 275);
            this.pictureWoman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureWoman.TabIndex = 0;
            this.pictureWoman.TabStop = false;
            // 
            // btnAvatar1
            // 
            this.btnAvatar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(206)))));
            this.btnAvatar1.FlatAppearance.BorderSize = 0;
            this.btnAvatar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvatar1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvatar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.btnAvatar1.Location = new System.Drawing.Point(116, 408);
            this.btnAvatar1.Name = "btnAvatar1";
            this.btnAvatar1.Size = new System.Drawing.Size(226, 49);
            this.btnAvatar1.TabIndex = 16;
            this.btnAvatar1.Text = "Ảnh 1";
            this.btnAvatar1.UseVisualStyleBackColor = false;
            this.btnAvatar1.Click += new System.EventHandler(this.btnAvatar1_Click);
            // 
            // btnAvatar2
            // 
            this.btnAvatar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(206)))));
            this.btnAvatar2.FlatAppearance.BorderSize = 0;
            this.btnAvatar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvatar2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvatar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.btnAvatar2.Location = new System.Drawing.Point(586, 408);
            this.btnAvatar2.Name = "btnAvatar2";
            this.btnAvatar2.Size = new System.Drawing.Size(226, 49);
            this.btnAvatar2.TabIndex = 16;
            this.btnAvatar2.Text = "Ảnh 2";
            this.btnAvatar2.UseVisualStyleBackColor = false;
            this.btnAvatar2.Click += new System.EventHandler(this.btnAvatar2_Click);
            // 
            // btnExist
            // 
            this.btnExist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.btnExist.FlatAppearance.BorderSize = 0;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Location = new System.Drawing.Point(885, 12);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(40, 35);
            this.btnExist.TabIndex = 17;
            this.btnExist.UseVisualStyleBackColor = false;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // SelectImageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(937, 547);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnAvatar2);
            this.Controls.Add(this.btnAvatar1);
            this.Controls.Add(this.pictureWoman);
            this.Controls.Add(this.pictureMan);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectImageFrm";
            this.Text = "SelectImageFrm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWoman)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureMan;
        private System.Windows.Forms.PictureBox pictureWoman;
        private System.Windows.Forms.Button btnAvatar1;
        private System.Windows.Forms.Button btnAvatar2;
        private System.Windows.Forms.Button btnExist;
    }
}