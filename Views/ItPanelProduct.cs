using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Views
{
    public partial class ItPanelProduct : Form
    {
        List<Product> products = new List<Product>();
        ProductController controller = new ProductController();
        public ItPanelProduct()
        {
            InitializeComponent();
            products = controller.LoadAllProduct();
        }

        private void txtProductFind_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtProductFind.Text == "Tìm kiếm:")
                txtProductFind.Text = "";
            
        }

        private void btnProductFind_Click(object sender, EventArgs e)
        {
            ProductInfo_CreateFrm f = new ProductInfo_CreateFrm();
            f.ShowDialog();

        }

        private void ItPanelProduct_Load(object sender, EventArgs e)
        {
            RemoveAll();
            foreach (var product in products)
            {
                ItProductInfo f = new ItProductInfo(product);
                f.TopLevel = false;
                flowPanelProduct.Controls.Add(f);
                f.Show();
            }
        }

        private void RemoveAll()
        {
            foreach (Control control in flowPanelProduct.Controls)
            {
                if (control is ItProductInfo itProductInfo)
                {
                    // Giải phóng tài nguyên của các hình ảnh trong control ItProductInfo
                    itProductInfo.Dispose();
                }
            }
            flowPanelProduct.Controls.Clear(); // Xóa tất cả các control cũ
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboFilter.SelectedIndex)
            {
                case 0:
                    {
                        //sắp theo mã tăng dần
                        controller.SortIdASC(products);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
                case 1:
                    {
                        //sắp theo mã giảm dần
                        controller.SortIdDESC(products);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
                case 2:
                    {
                        //sắp theo giá tăng dần
                        controller.SortPriceASC(products);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
                case 3:
                    {
                        //sắp theo giá giảm dần
                        controller.SortPriceDESC(products);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
                case 4:
                    {
                        //sắp theo tên a-z
                        controller.SortNameASC(products);
                        ItPanelProduct_Load(this, null);
                        break;
                    }

            }
        }

        private void txtProductFind_TextChanged(object sender, EventArgs e)
        {
            switch (comboProductFind.SelectedIndex)
            {
                case 0:
                    {
                        //Theo mã SP
                        products = controller.FindProductById(txtProductFind.Text);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
                case 1:
                    {
                        //Theo tên SP
                        products = controller.FindProductByName(txtProductFind.Text);
                        ItPanelProduct_Load(this, null);
                        break;
                    }
            }
        }
    }
}
