using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controllers;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
namespace Views
{
    public partial class ProductInfo_CreateFrm : Form
    {
        private List<Product> products = new List<Product>();
        private ProductController productController = new ProductController();
        private CheckInputController checkInputController = new CheckInputController();
        int currId;
        string avatarPath = "";

        //form khi tạo mới
        public ProductInfo_CreateFrm()
        {
            InitializeComponent();
            CenterToParent();
            btnAddEditProduct.Location = new Point(576, 688);
            btnRemoveProduct.Enabled = false;
            btnRemoveProduct.Visible = false;
            products = productController.LoadAllProduct();
            currId = productController.GetCurrId(products) + 1;
            txtProductId.Text = "SP" + currId;
            txtProductQuantity.Text = "0";
        }

        //form khi Show Info
        public ProductInfo_CreateFrm(Product product)
        {
            InitializeComponent();
            FormShowInfoSetting();
            CenterToParent();
            labelHeader.Text = "THÔNG TIN SẢN PHẨM";
            btnAddEditProduct.Text = "SỬA";
            FillData(product);
        }

        //Show các thông tin của sản phẩm lên form
        private void FillData(Product product)
        {
            txtProductId.Text = product.Id;
            txtProductName.Text = product.Name;
            txtProductPrice.Text = product.PriceStr;
            txtProductQuantity.Text = product.Quantity.ToString();
            txtProductMoreInfo.Text = product.Info;
            if (product.Size == "S") comboProductSize.SelectedIndex = 0;
            else if (product.Size == "M") comboProductSize.SelectedIndex = 1;
            else if (product.Size == "L") comboProductSize.SelectedIndex = 2;
            else if (product.Size == "XL") comboProductSize.SelectedIndex = 3;
            else if (product.Size == "XXL") comboProductSize.SelectedIndex = 4;
            else if (product.Size == "XXXL") comboProductSize.SelectedIndex = 5;

            if (product.Type == "Quần") comboProductType.SelectedIndex = 0;
            else if (product.Type == "Áo") comboProductType.SelectedIndex = 1;
            else if (product.Type == "Nón") comboProductType.SelectedIndex = 2;
            else if (product.Type == "Giày") comboProductType.SelectedIndex = 3;
            else if (product.Type == "Combo") comboProductType.SelectedIndex = 4;

            pictureProduct.ImageLocation = product.AvatarPath;
            avatarPath = product.AvatarPath;
        }

        //ẩn các textbox, chỉ cho xem
        private void FormShowInfoSetting()
        {
            txtProductId.Enabled = false;
            txtProductQuantity.Enabled = false;
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

        /// <summary>
        /// Chọn ảnh cho sản phẩm
        /// </summary>
        private void pictureProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho hộp thoại mở tệp
            openFileDialog.Title = "Chọn ảnh"; // Tiêu đề của hộp thoại
            openFileDialog.Filter = "Files(*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"; // Bộ lọc các loại tệp cho phép
            openFileDialog.Multiselect = false; // Chỉ cho phép chọn một tệp

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Hiển thị hộp thoại và kiểm tra xem người dùng đã chọn tệp hay không
            {
                // Lấy đường dẫn của tệp đã chọn
                avatarPath = openFileDialog.FileName;
                // Hiển thị ảnh đã chọn lên PictureBox
                pictureProduct.ImageLocation = avatarPath;
            }
        }

        private void btnAddEditNewProduct_Click(object sender, EventArgs e)
        {
            if (btnAddEditProduct.Text == "THÊM SẢN PHẨM")
                AddNewProduct();
            else if (btnAddEditProduct.Text == "SỬA")
                EditProduct();
        }

        //sửa sản phẩm
        private void EditProduct()
        {
            bool success = true;
            var id = txtProductId.Text;
            var name = txtProductName.Text;
            string priceStr = txtProductPrice.Text;
            int price = productController.GetPriceInt(priceStr);
            int quantity = int.Parse(txtProductQuantity.Text);
            string info = txtProductMoreInfo.Text;
            var type = "";
            if (comboProductType.SelectedIndex == 0)
                type = "Quần";
            else if (comboProductType.SelectedIndex == 1)
                type = "Áo";
            else if (comboProductType.SelectedIndex == 2)
                type = "Nón";
            else if (comboProductType.SelectedIndex == 3)
                type = "Giày";
            else if (comboProductType.SelectedIndex == 4)
                type = "Combo";
            else
                success = false;

            var size = "";
            if (comboProductSize.SelectedIndex == 0)
                size = "S";
            else if (comboProductSize.SelectedIndex == 1)
                size = "M";
            else if (comboProductSize.SelectedIndex == 2)
                size = "L";
            else if (comboProductSize.SelectedIndex == 3)
                size = "XL";
            else if (comboProductSize.SelectedIndex == 4)
                size = "XXL";
            else if (comboProductSize.SelectedIndex == 5)
                size = "XXXL";
            else
                success = false;

            if (success)
            {
                Product product = new Product(id, name, price, type, quantity, size, info, avatarPath);
                productController.EditProductInfo(product);
                MessageBox.Show("Sửa sản phẩm thành công! Vui lòng load lại trang để xem thông tin sản phẩm");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại");
            }
        }

        //Thêm mới sản phẩm
        private void AddNewProduct()
        {
            bool success = true;
            var id = txtProductId.Text;
            var name = txtProductName.Text;
            int price = int.Parse(txtProductPrice.Text);
            int quantity = int.Parse(txtProductQuantity.Text);
            string info = txtProductMoreInfo.Text;
            var type = "";
            if (comboProductType.SelectedIndex == 0)
                type = "Quần";
            else if (comboProductType.SelectedIndex == 1)
                type = "Áo";
            else if (comboProductType.SelectedIndex == 2)
                type = "Nón";
            else if (comboProductType.SelectedIndex == 3)
                type = "Giày";
            else if (comboProductType.SelectedIndex == 4)
                type = "Combo";
            else
                success = false;

            var size = "";
            if (comboProductSize.SelectedIndex == 0)
                size = "S";
            else if (comboProductSize.SelectedIndex == 1)
                size = "M";
            else if (comboProductSize.SelectedIndex == 2)
                size = "L";
            else if (comboProductSize.SelectedIndex == 3)
                size = "XL";
            else if (comboProductSize.SelectedIndex == 4)
                size = "XXL";
            else if (comboProductSize.SelectedIndex == 5)
                size = "XXXL";
            else
                success = false;

            if (success)
            {
                Product product = new Product(id, name, price, type, quantity, size, info, avatarPath);
                productController.CreateNewProduct(product);
                MessageBox.Show("Đăng ký thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại");
            }
        }

        //Xoá sản phẩm
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn muốn xoá?",
                "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
             if (res == DialogResult.Yes)
                if (productController.RemoveProduct(txtProductId.Text))
                    MessageBox.Show("Xoá sản phẩm thành công! " +
                        "Vui lòng load lại trang để xem thông tin sản phẩm");
                else
                    MessageBox.Show("Xoá sản phẩm thất bại!");
            this.Dispose();
        }
    }
}
