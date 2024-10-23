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
    public partial class ItBillInfoMain : Form
    {
        private Bill bill;
        public ItBillInfoMain(Bill bill)
        {
            InitializeComponent();
            this.bill = bill;

        }

        private void ItBillInfoMain_Load(object sender, EventArgs e)
        {
            txtBillId.Text = bill.Id;
            txtCustomerName.Text = bill.Customer.Name;
            txtDate.Text = bill.CreationTime.ToString("dd-MM-yyyy");
            txtDiscountedAmount.Text = GetPriceStr(bill.DiscountedPrice);
        }
        public string GetPriceStr(float price)
        {
            var priceStr = price.ToString();
            float number = float.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }


        private void panel4_Click(object sender, EventArgs e)
        {
            BillInfoFrm f = new BillInfoFrm(bill);
            f.ShowDialog();
        }
    }
}
