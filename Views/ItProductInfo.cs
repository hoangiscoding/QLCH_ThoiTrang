using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
namespace Views
{
    public partial class ItProductInfo : Form
    {
        private Product Product { get; set; }
        public ItProductInfo(Product product)
        {
            InitializeComponent();
            Product = product;
            FormLoad();
        }

        private void FormLoad()
        {
            if (Product.AvatarPath != "")
                pictureAvatar.ImageLocation = Product.AvatarPath;
            txtName.Text = Product.Name;
            txtPrice.Text = Product.PriceStr;

            //set nằm giữa cho tên sp
            txtName.Anchor = AnchorStyles.None;
            int x = (this.ClientSize.Width - txtName.Width) / 2;
            txtName.Location = new Point(x, 205);

            //set nằm giữa cho giá sp
            txtPrice.Anchor = AnchorStyles.None;
            int y = (this.ClientSize.Width - txtPrice.Width) / 2;
            txtPrice.Location = new Point(y, 230);

            //thiết lập màu cho label
            txtName.ForeColor = Color.Black;
            txtPrice.ForeColor = Color.Black;

        }

        private void ItProductInfo_MouseClick(object sender, MouseEventArgs e)
        {
            ProductInfo_CreateFrm f = new ProductInfo_CreateFrm(Product);
            f.ShowDialog();
        }

        private void panelProduct_MouseClick(object sender, MouseEventArgs e)
        {
            ProductInfo_CreateFrm f = new ProductInfo_CreateFrm(Product);
            f.ShowDialog();
        }
    }
}
