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
    public partial class ItImportGoodInfo : Form
    {
        public ImportGood ImportGood { get; set; }
        private ImportGoodCreateFrm parentForm;
        public int Sum { get; set; }
        public ItImportGoodInfo(ImportGood import, ImportGoodCreateFrm parentForm)
        {
            InitializeComponent();
            ImportGood = import;
            this.parentForm = parentForm;
            LoadControls();
        }public ItImportGoodInfo(ImportGood import)
        {
            InitializeComponent();
            ImportGood = import;
            LoadControls();
        }

        private void LoadControls()
        {
            txtProductId.Text = ImportGood.Product.Id;
            txtProductName.Text = ImportGood.Product.Name;
            txtProductSize.Text = ImportGood.Product.Size;
            txtQuantity.Text = ImportGood.Quantity.ToString();
            Sum = ImportGood.Quantity * ImportGood.Product.Price;
            string sum = GetPriceStr(Sum);
            txtSum.Text = sum;
        }
        public string GetPriceStr(int price)
        {
            var priceStr = price.ToString();
            decimal number = decimal.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }

        private void panelImportGood_Click(object sender, EventArgs e)
        {
            parentForm.InitializeEdit(ImportGood);
        }

        /*public void UpdateImportGood(ImportGood importGood)
        {
            txtProductId.Text = importGood.Product.Id;
            txtProductName.Text = importGood.Product.Name;
            txtProductSize.Text = importGood.Product.Size;
            txtQuantity.Text = importGood.Quantity.ToString();
            Sum -= ImportGood.Product.Price;
            Sum += importGood.Quantity * importGood.Product.Price;
            string sum = GetPriceStr(Sum);
            txtSum.Text = sum;
        }*/
    }
}
