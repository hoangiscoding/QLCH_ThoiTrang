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
    }
}
