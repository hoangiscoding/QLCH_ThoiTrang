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
using System.Globalization;
namespace Views
{
    public partial class ItBillInfo : Form
    {
        private BillDetail billDetail;
        public ItBillInfo(BillDetail billDetail)
        {
            InitializeComponent();
            this.billDetail = billDetail;
        }

        private void ItBillInfo_Load(object sender, EventArgs e)
        {
            txtProductId.Text = billDetail.Product.Id;
            txtProductName.Text = billDetail.Product.Name;
            txtProductSize.Text = billDetail.Product.Size;
            txtQuantity.Text = billDetail.Quantity.ToString();
            txtTotal.Text = GetPriceStr(billDetail.Total);
        }
        public string GetPriceStr(int price)
        {
            var priceStr = price.ToString();
            decimal number = decimal.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }
        public string GetPriceStr(float price)
        {
            var priceStr = price.ToString();
            float number = float.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }
    }
}
