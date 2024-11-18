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
using Excel = Microsoft.Office.Interop.Excel;
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
        private Bill bill;
        private Product product;
        private Staff staff;
        private Customer customer;
        private BillDetail billDetail;
        private int currId;
        private int discountPercent;
        private int total;
        private float discountedAmount = 0f;
        private float originalAmount = 0f;
        private float discountAmount = 0f;
        public BillCreateFrm()
        {
            InitializeComponent();
            CenterToParent();
            txtDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public void InitializeEd(BillDetail billDetail)
        {

            this.billDetail = billDetail;

            txtPrice.Text = billDetail.Product.PriceStr;
            txtQuantity.Text = billDetail.Quantity + "";
            //txtImportGoodId.Text = importGood.Id;
            comboProduct.Items.Clear();
            foreach (var productItem in products)
            {
                comboProduct.Items.Add($"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}");
                if (billDetail.Product.Id == productItem.Id)
                    comboProduct.Text = $"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}";
            }

            //comboIdNameStaff.Items.Clear();
            //foreach (var staffItem in staffs)
            //{
            //    comboIdNameStaff.Items.Add($"{staffItem.Id} | {staffItem.Name}");
            //    if (importGood.Staff.Id == staffItem.Id)
            //        comboIdNameStaff.Text = $"{staffItem.Id} | {staffItem.Name}";
            //}
            btnRemoveProduct.Visible = true;

        }

        private void btnAddNewBill_Click(object sender, EventArgs e)
        {
            if (IsBillExist(txtBillId.Text))
            {
                //Bill đã được tạo thì tiến hành update
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
                    var staffId = GetIdOfCombo(comboStaff.Text.ToString());
                    var customerId = GetIdOfCombo(comboCustomer.SelectedItem.ToString());

                    //Tìm đối tượng tương ứng
                    staff = staffController.FindStaffById(staffs, staffId);
                    customer = customerController.FindCustomerById(customers, customerId);

                    DateTime creationTime = DateTime.ParseExact(txtDateTime.Text, "dd-MM-yyyy HH:mm:ss", null);
                    int quantity = int.Parse(txtQuantity.Text);

                    Bill bill = new Bill(billId, customer, staff, creationTime, discountAmount, originalAmount, discountAmount);
                    billController.CreateNewBill(bill);
                }

                customer.SetRank();
                //Gọi update bill
                BillUpdate();

            }

        }
        private void BillUpdate()
        {
            string productId = GetIdOfCombo(comboProduct.SelectedItem.ToString());
            int requiredQuantity = int.Parse(txtQuantity.Text);

            // Kiểm tra số lượng tồn kho
            if (product.Quantity < requiredQuantity)
            {
                MessageBox.Show("Số lượng trong kho không đủ. Vui lòng nhập số lượng nhỏ hơn hoặc chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BillDetail existingBillDetail = billDetails.FirstOrDefault(bd => bd.Product.Id == productId);

            if (existingBillDetail != null)
            {
                float addedTotal = existingBillDetail.Product.Price * requiredQuantity;
                existingBillDetail.Quantity += requiredQuantity;
                existingBillDetail.Total += addedTotal;

                UpdatePriceBill(addedTotal, "update");

                UpdateBillDetailUI(existingBillDetail);
            }
            else
            {
                BillDetail billDetail = CreateBillDetail(txtBillId.Text, productId, requiredQuantity);
                billDetails.Add(billDetail);

                ShowBillDetail(billDetail);

                UpdatePriceBill(billDetail.Total, "add");
            }

            // Giảm số lượng sản phẩm trong kho
            product.Quantity -= requiredQuantity;
            productController.UpdateProduct(product);

            comboProduct.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";

            FillProductIntoComboProduct();
        }

        private void UpdateBillDetailUI(BillDetail updatedBillDetail)
        {
            foreach (Control control in flowPanelProductInBill.Controls)
            {
                if (control is ItBillInfo billInfo)
                {
                    if (billInfo.BillDetail.Product.Id == updatedBillDetail.Product.Id)
                    {
                        flowPanelProductInBill.Controls.Remove(billInfo);
                        billInfo.Dispose();
                        break;
                    }
                }
            }

            ShowBillDetail(updatedBillDetail);
        }

        private void ShowBillDetail(BillDetail billDetail)
        {
            ItBillInfo f = new ItBillInfo(billDetail, this);
            f.TopLevel = false;
            flowPanelProductInBill.Controls.Add(f);
            f.Show();
        }
        private void UpdatePriceBill(float total, string status)
        {
            if (status == "add")
            {
                originalAmount += total;
            }
            else if (status == "update")
            {
                originalAmount += total;
            }

            if (discountPercent != 0)
                discountAmount = originalAmount * discountPercent * 0.01f;

            discountedAmount = originalAmount - discountAmount;

            // Set text
            txtOriginalPrice.Text = GetPriceStr(originalAmount);
            txtDiscountAmount.Text = GetPriceStr(discountAmount);
            txtTotal.Text = GetPriceStr(discountedAmount);

            billController.UpdateBill(txtBillId.Text, originalAmount, discountAmount, discountedAmount);
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
            if (billDetails.Count > 0)
            {
                var msg = "Hóa đơn chưa được thanh toán. Bạn có muốn hoàn tác các thay đổi?";
                var caption = "Cảnh báo";
                var result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (var billDetail in billDetails)
                    {
                        product = productController.FindProductById(products, billDetail.Product.Id);
                        product.Quantity += billDetail.Quantity;
                        productController.UpdateProduct(product);
                    }
                }
            }
            this.Dispose();
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
            string userId = UserInfo.UserId;
            string userName = UserInfo.UserName;
            comboStaff.Text = $"{userId} | {userName}";
            if (staff != null)
            {

                comboStaff.SelectedItem = $"{staff.Id} | {staff.Name}";
                comboStaff.Enabled = false;
            }
            btnRemoveProduct.Visible = false;

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
        private void TextNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string phoneNumber = textNumber.Text.Trim();
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = FindCustomerByPhone(customers, phoneNumber);

                if (customer != null)
                {
                    comboCustomer.Text = $"{customer.Id} | {customer.Name}";
                }
                else
                {
                    var customerForm = new CustomerInfo_CreateFrm
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };

                    if (customerForm.Controls.Find("txtCustomerPhone", true).FirstOrDefault() is TextBox txtCustomerPhone)
                    {
                        txtCustomerPhone.Text = phoneNumber;
                        txtCustomerPhone.Enabled = false;
                    }

                    customerForm.ShowDialog();

                    customers = customerController.LoadAllCustomer();
                    FillCustomerIntoComboCustomer();

                    customer = FindCustomerByPhone(customers, phoneNumber);
                    if (customer != null)
                    {
                        comboCustomer.Text = $"{customer.Id} | {customer.Name}";
                    }
                }
            }
        }
        public Customer FindCustomerByPhone(List<Customer> customers, string phoneNumber)
        {
            return customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
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

        public void PrintBillPay()
        {
            if (comboCustomer.Text != "" || txtBillId.Text != "" || flowPanelProductInBill.Controls.Count > 0)
            {

                Excel.Application exApp = new Excel.Application();

                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1];


                Excel.Range dc = (Excel.Range)exSheet.Cells[2, 1];
                dc.Font.Size = 13;
                dc.Font.Color = Color.Blue;
                dc.Value = "ĐHGTVT - Hà Nội";

                //In chữ Hóa đơn bán
                exSheet.Range["D4"].Font.Size = 20;
                exSheet.Range["D4"].Font.Bold = true;
                exSheet.Range["D4"].Font.Color = Color.Red;
                exSheet.Range["D4"].Value = "HÓA ĐƠN BÁN HÀNG";

                //In các Thông tin chung
                exSheet.Range["A5:A8"].Font.Size = 12;
                exSheet.Range["A5"].Value = "Mã hóa đơn: " + txtBillId.Text;
                exSheet.Range["A6"].Value = "Khách hàng: " + comboCustomer.Text;
                exSheet.Range["A7"].Value = "Thời gian: " + txtDateTime.Text;
                exSheet.Range["A8"].Value = "Khuyến mãi: " + txtDiscountPercent.Text;


                //In dòng tiêu đề
                exSheet.Range["A10:G10"].Font.Size = 12;
                exSheet.Range["A10:G10"].Font.Bold = true;
                exSheet.Range["C10"].ColumnWidth = 25;
                exSheet.Range["G10"].ColumnWidth = 25;
                exSheet.Range["E10"].ColumnWidth = 20;
                exSheet.Range["F10"].ColumnWidth = 20;
                exSheet.Range["B10"].ColumnWidth = 20;
                exSheet.Range["D10"].ColumnWidth = 20;
                exSheet.Range["A10"].Value = "STT";
                exSheet.Range["B10"].Value = "Mã hàng";
                exSheet.Range["C10"].Value = "Tên hàng";
                exSheet.Range["D10"].Value = "Số lượng";
                exSheet.Range["E10"].Value = "Đơn giá bán";
                exSheet.Range["F10"].Value = "Thành tiền";

                //In ds chi tiết các mặt hàng trong hóa đơn
                int row = 11;
                int stt = 1;
                foreach (Control control in flowPanelProductInBill.Controls)
                {
                    if (control is ItBillInfo itBillInfo)
                    {
                        exSheet.Range["A" + (row).ToString()].Value = stt.ToString();
                        exSheet.Range["B" + (row).ToString()].Value = itBillInfo.BillDetail.Product.Id.ToString();
                        exSheet.Range["C" + (row).ToString()].Value = itBillInfo.BillDetail.Product.Name.ToString();
                        exSheet.Range["D" + (row).ToString()].Value = itBillInfo.BillDetail.Quantity.ToString();
                        exSheet.Range["E" + (row).ToString()].Value = itBillInfo.BillDetail.Product.Price;
                        exSheet.Range["F" + (row).ToString()].Value = itBillInfo.BillDetail.Total.ToString();
                        row++;
                        stt++;
                    }
                }
                exSheet.Range["F" + (row + 1).ToString()].Value = "Tổng tiền: " + txtTotal.Text;
                exSheet.Range["F" + (row + 2).ToString()].Value = "Nhân viên: " + comboStaff.Text;
                exSheet.Name = txtBillId.Text;
                exBook.Activate();

                //Lưu file
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file Workbook|*.xls|Excel Workbook| *.xlsx|All Files|*.*";
                save.FilterIndex = 2;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(save.FileName.ToLower());
                    MessageBox.Show("Đã lưu file thành công!");
                }
                exApp.Quit();
            }
            else
            {
                MessageBox.Show("Không đủ thông tin");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (billDetails.Count == 0)
            {
                MessageBox.Show("Hóa đơn không có sản phẩm. Vui lòng thêm sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = MessageBox.Show("Bạn có chắc chắn muốn thanh toán?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var res1 = MessageBox.Show("Thanh toán thành công!\nBạn có muốn in hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res1 == DialogResult.Yes)
                {
                    PrintBillPay();
                }
                Payment();
            }
        }


        private void Payment()
        {
            customerController.UpdatePaymentCustomer(discountedAmount, customer.Id);
            customers = customerController.LoadAllCustomer();

            billController.PayBill(txtBillId.Text, originalAmount, discountAmount, discountedAmount);

            foreach (var billDetail in billDetails)
            {
                billController.CreateNewBillDetail(billDetail);
            }

            billDetails.Clear();

            ResetForm();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá?",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                billController.RemoveBillDetail(billDetail);

                //remove khỏi flowpanel
                // Tìm panel có ID trùng khớp
                foreach (Control control in flowPanelProductInBill.Controls)
                {
                    if (control is ItBillInfo itBillInfo && itBillInfo.BillDetail.Id == billDetail.Id)
                    {
                        flowPanelProductInBill.Controls.Remove(control);
                        product = productController.FindProductById(products, billDetail.Product.Id);
                        product.Quantity += billDetail.Quantity;
                        productController.UpdateProduct(product);
                    }
                }

                //Load lại trang
                BillCreateFrm_Load(this, null);

                ClearInfo();

                MessageBox.Show("Xoá thành công!");
                btnRemoveProduct.Visible = false;

            }
        }

        private void ClearInfo()
        {
            comboProduct.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        private void ResetForm()
        {
            textNumber.Text = "";
            comboCustomer.Text = "";
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

            flowPanelProductInBill.Controls.Clear();

            // Load lại dữ liệu khách hàng
            customers = customerController.LoadAllCustomer();
        }

        
    }
}