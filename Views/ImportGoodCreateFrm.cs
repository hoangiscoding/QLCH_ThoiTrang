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
using System.Runtime.ConstrainedExecution;
namespace Views
{
    public partial class ImportGoodCreateFrm : Form
    {
        List<Staff> staffs = new List<Staff>();
        List<Product> products = new List<Product>();
        List<ImportGood> importGoods = new List<ImportGood>();
        StaffController staffController = new StaffController();
        ProductController productController = new ProductController();
        ImportGoodController imController = new ImportGoodController();
        private Product product;
        private Staff staff;
        private int currId;
        private int total;
        private ImportGood importGood;
        //form tạo mới
        public ImportGoodCreateFrm()
        {
            InitializeComponent();
            CenterToParent();
            txtTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public void InitializeEdit(ImportGood importGood)
        {

            this.importGood = importGood;
            txtCost.Text = importGood.Product.CostStr;
            txtQuantity.Text = importGood.Quantity + "";
            txtImportGoodId.Text = importGood.Id;
            comboIdNameSizeQuantityProduct.Items.Clear();
            foreach (var productItem in products)
            {
                comboIdNameSizeQuantityProduct.Items.Add($"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}");
                if (importGood.Product.Id == productItem.Id)
                    comboIdNameSizeQuantityProduct.Text = $"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}";
            }

            comboIdNameStaff.Items.Clear();
            foreach (var staffItem in staffs)
            {
                comboIdNameStaff.Items.Add($"{staffItem.Id} | {staffItem.Name}");
                if (importGood.Staff.Id == staffItem.Id)
                    comboIdNameStaff.Text = $"{staffItem.Id} | {staffItem.Name}";
            }
            btnRemoveImportGood.Visible = true;

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ImportGoodCreateFrm_Load(object sender, EventArgs e)
        {
            staffs = staffController.LoadAllStaff();
            products = productController.LoadAllProduct();
            importGoods = imController.LoadAllImportGood();
            FillStaffIntoComboStaff();
            FillProductIntoComboProduct();
            currId = imController.GetCurrId(importGoods) + 1;
            txtImportGoodId.Text = "IM" + currId;
            string userId = UserInfo.UserId;
            string userName = UserInfo.UserName;
            comboIdNameStaff.Text = $"{userId} | {userName}";
            if (staff != null)
            {
                comboIdNameStaff.SelectedItem = $"{staff.Id} | {staff.Name}";
                comboIdNameStaff.Enabled = false;
            }
            btnRemoveImportGood.Visible = false;
        }

        private void FillProductIntoComboProduct()
        {
            comboIdNameSizeQuantityProduct.Items.Clear();
            foreach (var productItem in products)
            {
                comboIdNameSizeQuantityProduct.Items.Add($"{productItem.Id} | {productItem.Name} |" +
                    $" {productItem.Size} | {productItem.Quantity}");
            }
        }

        private void FillStaffIntoComboStaff()
        {
            comboIdNameStaff.Items.Clear();
            foreach (var staffItem in staffs)
            {
                comboIdNameStaff.Items.Add($"{staffItem.Id} | {staffItem.Name}");
            }
        }

        private void comboIdNameSizeQuantityProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GetIdOfComboProduct(comboIdNameSizeQuantityProduct.Text);
            product = productController.FindProductById(products, id);
            if (product != null)
            {
                txtCost.Text = product.CostStr;
            }
        }

        private string GetIdOfComboProduct(string text)
        {
            return text.Substring(0, text.IndexOf("|")).Trim();
        }

        private void comboIdNameStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GetIdOfComboStaff(comboIdNameStaff.Text);
            staff = staffController.FindStaffById(staffs, id);
        }

        private string GetIdOfComboStaff(string text)
        {
            return text.Substring(0, text.IndexOf("|")).Trim();
        }

        private void btnAddNewImportGood_Click(object sender, EventArgs e)
        {
            if (btnAddEditImportGood.Text == "THÊM")
                AddNewImportGood();
        }

        private void AddNewImportGood()
        {
            bool success = true;
            var id = txtImportGoodId.Text;
            DateTime time = DateTime.Now;
            int quantity = 0;
            try
            {
                quantity = int.Parse(txtQuantity.Text);
                if (quantity < 0)
                {
                    success = false;
                    MessageBox.Show("Số lượng phải > 0",
                       "Thông báo", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Số lượng phải là số",
                   "Thông báo", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                success = false;
            }
            if (comboIdNameSizeQuantityProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm",
                    "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                success = false;

            }
            var staffId = GetIdOfComboStaff(comboIdNameStaff.Text.ToString());
            staff = staffController.FindStaffById(staffs, staffId);
            ImportGood importGood = new ImportGood(id, staff, product, time, quantity, total);
            if (success)
            {
                imController.CreateNewImportGood(importGood);
                MessageBox.Show("Thêm mới thông tin nhập hàng thành công!");

                ItImportGoodInfo f = new ItImportGoodInfo(importGood, this);
                f.TopLevel = false;
                flowPanelImportGood.Controls.Add(f);
                f.Show();

                ImportGoodCreateFrm_Load(this, null);

                ClearInfo();
            }
            else
            {
                MessageBox.Show("Thêm mới thông tin nhập hàng thất bại!");
            }

        }

        private void ClearInfo()
        {
            comboIdNameSizeQuantityProduct.Text = "";
            txtQuantity.Text = "";
            txtCost.Text = "";
        }

        public string GetCostStr(int cost)
        {
            var costStr = cost.ToString();
            decimal number = decimal.Parse(costStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string costFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return costFormatted;
        }
        public int GetcostInt(string costStr)
        {
            // Xóa ký tự mẫu của tiền tệ (VD: "$", "€", "₫")
            costStr = costStr.Replace("₫", "").Trim();

            // Loại bỏ ký tự phân cách hàng nghìn
            costStr = costStr.Replace(".", "");

            // Thay thế dấu phân cách thập phân
            costStr = costStr.Replace(",", ".");

            // Chuyển đổi chuỗi thành số
            int number = (int)decimal.Parse(costStr, CultureInfo.InvariantCulture);
            return number;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            btnAddEditImportGood.Text = "THÊM";
            btnAddEditImportGood.Visible = true;
            ImportGoodCreateFrm_Load(this, null);
            ClearInfo();
        }

        private void btnRemoveImportGood_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá?",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                imController.RemoveImportGood(importGood);

                //xử lý giảm tiền
                total -= importGood.Quantity * importGood.Product.Cost;
                var totalStr = GetCostStr(total);

                //remove khỏi flowpanel
                // Tìm panel có ID trùng khớp
                foreach (Control control in flowPanelImportGood.Controls)
                {
                    if (control is ItImportGoodInfo itImportGoodInfo && itImportGoodInfo.ImportGood.Id == importGood.Id)
                    {
                        flowPanelImportGood.Controls.Remove(control);
                    }
                }

                //Load lại trang
                ImportGoodCreateFrm_Load(this, null);

                ClearInfo();

                MessageBox.Show("Xoá thành công. Vui lòng nhấn 'LÀM MỚI'!");
                btnRemoveImportGood.Visible = false;

            }
        }
    }
}
