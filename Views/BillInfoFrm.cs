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
using Excel = Microsoft.Office.Interop.Excel;

namespace Views
{
    public partial class BillInfoFrm : Form
    {
        
        List<Customer> customers = new List<Customer>();
        List<BillDetail> billDetails = new List<BillDetail>();
        List<Product> products = new List<Product>();
        BillController billController = new BillController();
        CustomerController customerController = new CustomerController();
        ProductController productController = new ProductController();
        private Customer customer;
        private BillDetail billDetail;
        private int discountPercent = 0;
        private Bill bill;
        private Product product;
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

        public void PrintBillPay()
        {
            if (txtCustomer.Text != "" || txtBillId.Text != "" || flowPanelProductInBill.Controls.Count > 0)
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
                exSheet.Range["A6"].Value = "Khách hàng: " + txtCustomer.Text;
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
                exSheet.Range["F" + (row + 2).ToString()].Value = "Nhân viên: " + txtStaff.Text;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBillPay();
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá?",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                billController.RemoveBill(bill);

                //remove khỏi flowpanel
                // Tìm panel có ID trùng khớp
                foreach (Control control in flowPanelProductInBill.Controls)
                {
                    if (control is ItBillInfo itBillInfo && itBillInfo.Bill.Id == bill.Id)
                    {
                        flowPanelProductInBill.Controls.Remove(control);
                        product = productController.FindProductById(products, billDetail.Product.Id);
                        product.Quantity += billDetail.Quantity;
                        productController.UpdateProduct(product);
                    }
                }

                MessageBox.Show("Xoá thành công");
                this.Hide();

            }
        }
    }
}
