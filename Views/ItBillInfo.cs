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
using Twilio.TwiML.Voice;
namespace Views
{
    public partial class ItBillInfo : Form
    {
        public BillDetail BillDetail { get; set; }
        private BillCreateFrm prtFrm;
        public ItBillInfo(BillDetail billDetail, BillCreateFrm prtFrm)
        {
            InitializeComponent();
            BillDetail = billDetail;
            this.prtFrm = prtFrm;
            LoadControls();
        }
        public ItBillInfo(BillDetail billDetail)
        {
            InitializeComponent();
            BillDetail = billDetail;
            LoadControls();
        }
        private void LoadControls()
        {
            txtProductId.Text = BillDetail.Product.Id;
            txtProductName.Text = BillDetail.Product.Name;
            txtProductSize.Text = BillDetail.Product.Size;
            txtQuantity.Text = BillDetail.Quantity.ToString();
            //Sum = BillDetail.Quantity * BillDetail.Product.Price;
            //string sum = GetPriceStr(Sum);
            //txtSum.Text = sum;
        }

        private void ItBillInfo_Load(object sender, EventArgs e)
        {
            txtProductId.Text = BillDetail.Product.Id;
            txtProductName.Text = BillDetail.Product.Name;
            txtProductSize.Text = BillDetail.Product.Size;
            txtQuantity.Text = BillDetail.Quantity.ToString();
            txtTotal.Text = GetPriceStr(BillDetail.Total);
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
        private void panelBillInfo_Click(object sender, EventArgs e)
        {
            if (prtFrm != null)
            {
                prtFrm.InitializeEd(BillDetail);
            }
            else
            {
                MessageBox.Show("Print form is not initialized.");
            }
        }
    }
}
