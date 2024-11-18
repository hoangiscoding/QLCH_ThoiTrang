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
using Excel = Microsoft.Office.Interop.Excel;
using Twilio.TwiML.Voice;
namespace Views
{
    public partial class ImportGoodInfoFrm : Form
    {
        private ImportGood importGood;
        public ImportGoodInfoFrm(ImportGood import)
        {
            InitializeComponent();
            CenterToParent();
            importGood = import;
        }

        private void btnDeleteImportGood_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ImportGoodInfoFrm_Load(object sender, EventArgs e)
        {
            txtStaff.Text = $"{importGood.Staff.Id} | {importGood.Staff.Name}";
            txtImportDate.Text = $"{importGood.ImportTime.ToString("dd-MM-yy HH:mm:ss")}";
            txtImportGoodId.Text = $"{importGood.Id}";
            ItImportGoodInfo f = new ItImportGoodInfo(importGood);
            f.TopLevel = false;
            flowPanelImportGood.Controls.Add(f);
            f.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtStaff.Text != "" || txtImportDate.Text != "" || txtImportGoodId.Text != "" || flowPanelImportGood.Controls.Count>0)
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
                exSheet.Range["D4"].Value = "HÓA ĐƠN NHẬP HÀNG";

                //In các Thông tin chung
                exSheet.Range["A5:A8"].Font.Size = 12;
                exSheet.Range["A5"].Value = "Mã phiếu nhập: " + txtImportGoodId.Text;
                exSheet.Range["A6"].Value = "Nhân viên: " + txtStaff.Text;
                exSheet.Range["A7"].Value = "Thời gian: " + txtImportDate.Text;


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
                exSheet.Range["D10"].Value = "Size";
                exSheet.Range["E10"].Value = "Số lượng";
                exSheet.Range["F10"].Value = "Thành tiền";

                //In ds chi tiết các mặt hàng trong hóa đơn
                int row = 11;
                int stt = 1;
                foreach (Control control in flowPanelImportGood.Controls)
                {
                    if (control is ItImportGoodInfo itImportGoodInfo)
                    {
                        exSheet.Range["A" + (row).ToString()].Value = stt.ToString();
                        exSheet.Range["B" + (row).ToString()].Value = itImportGoodInfo.ImportGood.Product.Id.ToString();
                        exSheet.Range["C" + (row).ToString()].Value = itImportGoodInfo.ImportGood.Product.Name.ToString();
                        exSheet.Range["D" + (row).ToString()].Value = itImportGoodInfo.ImportGood.Quantity.ToString();
                        exSheet.Range["E" + (row).ToString()].Value = itImportGoodInfo.ImportGood.Product.Price;
                        exSheet.Range["F" + (row).ToString()].Value = itImportGoodInfo.Sum.ToString();
                        row++;
                        stt++;
                    }
                    
                }
                exSheet.Name = txtImportGoodId.Text;
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
    }
}
