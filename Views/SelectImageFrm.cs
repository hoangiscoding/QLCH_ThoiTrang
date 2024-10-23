using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class SelectImageFrm : Form
    {
        private string selectedImagePath;
        private string imgPath1, imgPath2;

        public SelectImageFrm(string imagePath1, string imagePath2)
        {
            InitializeComponent();
            CenterToParent();
            imgPath1 = imagePath1;
            imgPath2 = imagePath2;
            // Hiển thị hai hình ảnh trong hai PictureBox
            pictureMan.Image = new Bitmap(imagePath1);
            pictureWoman.Image = new Bitmap(imagePath2);
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn thoát?";
            var caption = "Thông báo";
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnAvatar2_Click(object sender, EventArgs e)
        {
            selectedImagePath = imgPath2;
            this.Dispose();
        }

        private void btnAvatar1_Click(object sender, EventArgs e)
        {
            selectedImagePath = imgPath1;
            this.Dispose();
        }
        public string GetSelectedImagePath()
        {
            return selectedImagePath;
        }
    }
}
