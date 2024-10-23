using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controllers;
using System.Globalization;

namespace Views
{
    public partial class BillInfoFrm : Form
    {
        private Bill bill;
        List<Customer> customers = new List<Customer>();
        List<BillDetail> billDetails = new List<BillDetail>();
        BillController billController = new BillController();
        CustomerController customerController = new CustomerController();
        private Customer customer;
        private int discountPercent = 0;
        public BillInfoFrm(Bill bill)
        {
            InitializeComponent();
            CenterToParent();
            this.bill = bill;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn thoát?";
            var title = "Thông báo";
            var res = MessageBox.Show(msg, title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void BillInfoFrm_Load(object sender, EventArgs e)
        {
            customers = customerController.LoadAllCustomer();
            txtBillId.Text = bill.Id;
            txtStaff.Text = $"{bill.Staff.Id} | {bill.Staff.Name}";
            txtCustomer.Text = $"{bill.Customer.Id} | {bill.Customer.Name}";
            txtDateTime.Text = bill.CreationTime.ToString("dd-MM-yyyy HH:mm:ss");
            customer = customerController.FindCustomerById(customers, bill.Customer.Id);
            if (customer.Rank == "ĐỒNG")
            {
                discountPercent = 0;
                txtDiscountPercent.Text = $"{discountPercent}%";
            }
            else if (customer.Rank == "BẠC")
            {
                discountPercent = 5;
                txtDiscountPercent.Text = $"{discountPercent}%";
            }
            else if (customer.Rank == "VÀNG")
            {
                discountPercent = 10;
                txtDiscountPercent.Text = $"{discountPercent}%";
            }
            else if (customer.Rank == "KIM CƯƠNG")
            {
                discountPercent = 15;
                txtDiscountPercent.Text = $"{discountPercent}%";
            }
            txtOriginalPrice.Text = GetPriceStr(bill.OriginalAmnount);
            txtDiscountAmount.Text = GetPriceStr(bill.DiscountAmount);
            txtTotal.Text = GetPriceStr(bill.DiscountedPrice);

            LoadBillDetails();

            foreach (var billDetail in billDetails)
            {
                if (billDetail.Id == bill.Id)
                {
                    ItBillInfo f = new ItBillInfo(billDetail);
                    f.TopLevel = false;
                    flowPanelProductInBill.Controls.Add(f);
                    f.Show();
                }
            }

        }

        private void LoadBillDetails()
        {
            billDetails = billController.LoadBillDetail();
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
