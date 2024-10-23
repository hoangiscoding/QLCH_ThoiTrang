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
    public partial class BillCreateFrm : Form
    {
        List<Staff> staffs = new List<Staff>();
        List<Product> products = new List<Product>();
        List<Customer> customers = new List<Customer>();
        List<Bill> bills = new List<Bill>();
        List<BillDetail> billDetails = new List<BillDetail>();
        StaffController staffController = new StaffController();
        ProductController productController = new ProductController();
        CustomerController customerController = new CustomerController();
        BillController billController = new BillController();
        private Product product;
        private Staff staff;
        private Customer customer;
        private int currId;
        private int discountPercent;
        private float discountedAmount = 0f;
        private float originalAmount = 0f;
        private float discountAmount = 0f;
        public BillCreateFrm()
        {
            InitializeComponent();
            CenterToParent();
            txtDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void btnAddNewBill_Click(object sender, EventArgs e)
        {
            if (IsBillExist(txtBillId.Text))
            {
                //Bill đã được tạo thì tiến hành update thôi
                BillUpdate();
            }
            else
            {
                //Bill chưa được tạo thì tiến hành tạo bill mới với các thông tin về giá  = 0
                var success = true;
                if (comboCustomer.SelectedIndex == -1)
                {
                    success = false;
                    MessageBox.Show("Vui lòng chọn thông tin khách hàng.");
                }
                else if (comboStaff.SelectedIndex == -1)
                {
                    success = false;
                    MessageBox.Show("Vui lòng chọn thông tin nhân viên.");
                }
                if (comboProduct.SelectedIndex == -1)
                {
                    success = false;
                    MessageBox.Show("Vui lòng chọn thông tin sản phẩm.");
                }
                else if (txtQuantity.Text == "")
                {
                    success = false;
                    MessageBox.Show("Vui lòng nhập số lượng sản phẩm.");
                }
                else if (int.Parse(txtQuantity.Text) > GetQuanntityOfProduct(comboProduct.SelectedItem.ToString()))
                {
                    success = false;
                    MessageBox.Show("Không đủ số lượng yêu cầu");
                }
                else
                {
                    //ẩn không cho sửa thông tin nhân viên và khách hàng
                    comboCustomer.Enabled = false;
                    comboStaff.Enabled = false;
                }

                if (success != false)
                {
                    var billId = txtBillId.Text;
                    var staffId = GetIdOfCombo(comboStaff.SelectedItem.ToString());
                    var customerId = GetIdOfCombo(comboCustomer.SelectedItem.ToString());

                    //Tìm đối tượng tương ứng
                    staff = staffController.FindStaffById(staffs, staffId);
                    customer = customerController.FindCustomerById(customers, customerId);

                    DateTime creationTime = DateTime.ParseExact(txtDateTime.Text, "dd-MM-yyyy HH:mm:ss", null);
                    int quantity = int.Parse(txtQuantity.Text);

                    Bill bill = new Bill(billId, customer, staff, creationTime, discountAmount, originalAmount, discountAmount);
                    billController.CreateNewBill(bill);
                }

                //Gọi update bill
                BillUpdate();

            }

        }

        private void BillUpdate()
        {
            //tạo billdetail -> thêm vào list billdetail, update giá của bill
            BillDetail billDetail = CreateBillDetail(
                txtBillId.Text,
                GetIdOfCombo(comboProduct.SelectedItem.ToString()),
                int.Parse(txtQuantity.Text)
                );

            billDetails.Add(billDetail);

            //Show bill detail lên flowpanel
            ShowBillDetail(billDetail);
            UpdatePriceBill(billDetail.Total, "add");

            //Trừ đi số lượng đã thêm từ sản phẩm
            product.Quantity -= int.Parse(txtQuantity.Text);
            productController.UpdateProduct(product);

            //reset text thành ""
            comboProduct.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            //Load lại số lượng sản phẩm
            FillProductIntoComboProduct();


        }

        private void ShowBillDetail(BillDetail billDetail)
        {
            ItBillInfo f = new ItBillInfo(billDetail);
            f.TopLevel = false;
            flowPanelProductInBill.Controls.Add(f);
            f.Show();
        }

        private void UpdatePriceBill(float total, string status)
        {
            if (status == "add")
            {
                originalAmount += total;
                if (discountPercent != 0)
                    discountAmount = originalAmount * discountPercent * 0.01f;
                discountedAmount = originalAmount - discountAmount;

                //set text
                txtOriginalPrice.Text = GetPriceStr(originalAmount);
                txtDiscountAmount.Text = GetPriceStr(discountAmount);
                txtTotal.Text = GetPriceStr(discountedAmount);

                billController.UpdateBill(txtBillId.Text, originalAmount, discountAmount, discountedAmount);
            }
        }

        private BillDetail CreateBillDetail(string billId, string productId, int quantity)
        {
            product = productController.FindProductById(products, productId);
            float total = product.Price * quantity;
            return new BillDetail(billId, product, quantity, total);
        }

        private bool IsBillExist(string billId)
        {
            foreach (Bill bill in bills)
            {
                if (bill.Id == billId)
                    return true;
            }
            return false;
        }

        private int GetQuanntityOfProduct(string str)
        {
            var data = str.Split('|');
            return int.Parse(data[3].Trim());
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

        private void BillCreateFrm_Load(object sender, EventArgs e)
        {
            staffs = staffController.LoadAllStaff();
            products = productController.LoadAllProduct();
            customers = customerController.LoadAllCustomer();
            bills = billController.LoadAllBill();
            FillStaffIntoComboStaff();
            FillProductIntoComboProduct();
            FillCustomerIntoComboCustomer();
            currId = billController.GetCurrId(bills) + 1;
            txtBillId.Text = "BI" + currId;
        }

        private void FillCustomerIntoComboCustomer()
        {
            comboCustomer.Items.Clear();
            foreach (var customerItem in customers)
            {
                comboCustomer.Items.Add($"{customerItem.Id} | {customerItem.Name}");
            }
        }

        private void FillProductIntoComboProduct()
        {
            comboProduct.Items.Clear();
            foreach (var productItem in products)
            {
                comboProduct.Items.Add($"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}");
            }
        }

        private void FillStaffIntoComboStaff()
        {
            comboStaff.Items.Clear();
            foreach (var staffItem in staffs)
            {
                comboStaff.Items.Add($"{staffItem.Id} | {staffItem.Name}");
            }
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GetIdOfCombo(comboProduct.Text);
            product = productController.FindProductById(products, id);
            if (product != null)
            {
                txtPrice.Text = product.PriceStr;
            }
        }

        private string GetIdOfCombo(string text)
        {
            return text.Substring(0, text.IndexOf("|")).Trim();
        }

        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GetIdOfCombo(comboCustomer.Text);
            customer = customerController.FindCustomerById(customers, id);
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
            txtRevenue.Text = GetPriceStr(customer.Revenue);
        }
        public string GetPriceStr(float price)
        {
            var priceStr = price.ToString();
            float number = float.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc chắn muốn thanh toán?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Payment();
            }
        }

        private void Payment()
        {
            customerController.UpdatePaymentCustomer(discountedAmount, customer.Id);
            customers = customerController.LoadAllCustomer();
            billController.PayBill(txtBillId.Text, originalAmount, discountAmount,
                discountedAmount);

            //Clear dữ liệu
            comboCustomer.Enabled = true;
            comboStaff.Enabled = true;
            comboCustomer.Text = "";
            comboStaff.Text = "";
            comboProduct.Text = "";
            currId++;
            txtBillId.Text = "BI" + currId;
            txtDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            txtPrice.Text = "0 VNĐ";
            txtQuantity.Text = "";
            txtDiscountPercent.Text = "0%";
            discountedAmount = 0f;
            originalAmount = 0f;
            discountAmount = 0f;
            txtDiscountAmount.Text = GetPriceStr(discountAmount);
            txtOriginalPrice.Text = GetPriceStr(originalAmount);
            txtTotal.Text = GetPriceStr(discountedAmount);
            txtRevenue.Text = "0 VNĐ";

            //update khách hàng
            customers = customerController.LoadAllCustomer();

            flowPanelProductInBill.Controls.Clear();

            //lưu thông tin của billdetails
            List<BillDetail> newBillDetails = new List<BillDetail>(); // Danh sách tạm thời để lưu trữ các BillDetail mới

            foreach (var billDetail in billDetails)
            {
                newBillDetails.Add(billDetail);
            }

            // Thêm tất cả các BillDetail mới vào cơ sở dữ liệu
            foreach (var billDetail in newBillDetails)
            {
                billController.CreateNewBillDetail(billDetail);
            }
        }
    }
}
