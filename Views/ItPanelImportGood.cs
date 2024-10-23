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
namespace Views
{
    public partial class ItPanelImportGood : Form
    {
        private List<ImportGood> importGoods = new List<ImportGood>();
        private ImportGoodController importGoodController = new ImportGoodController();
        public ItPanelImportGood()
        {
            InitializeComponent();
            importGoods = importGoodController.LoadAllImportGood();
        }

        private void btnImportGoodCreate_Click(object sender, EventArgs e)
        {
            ImportGoodCreateFrm frm = new ImportGoodCreateFrm();
            frm.ShowDialog();
        }

        private void ItPanelImportGood_Load(object sender, EventArgs e)
        {
            flowPanelImportGood.Controls.Clear(); // Xóa tất cả các control cũ

            foreach (var importGood in importGoods)
            {
                ItImportGoodMain f = new ItImportGoodMain(importGood);
                f.TopLevel = false;
                flowPanelImportGood.Controls.Add(f);
                f.Show();
            }
        }

        private void txtGoodFind_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtGoodFind.Text == "Tìm kiếm:")
                txtGoodFind.Text = "";
        }

        private void txtGoodFind_TextChanged(object sender, EventArgs e)
        {
            switch (comboGoodFind.SelectedIndex)
            {
                case 0:
                    {
                        //Tìm theo mã phiếu
                        importGoods = importGoodController.FindImportGoodById(txtGoodFind.Text);
                        ItPanelImportGood_Load(this, null);
                        break;
                    }
                case 1:
                    {
                        //Tìm theo tên NV
                        importGoods = importGoodController.FindImportGoodByStaffName(txtGoodFind.Text);
                        ItPanelImportGood_Load(this, null);
                        break;
                    }
                case 2:
                    {
                        //Tìm theo ngày
                        importGoods = importGoodController.FindImportGoodByDate(txtGoodFind.Text);
                        ItPanelImportGood_Load(this, null);
                        break;
                    }
            }
        }
    }
}
