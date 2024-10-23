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
    public partial class ItImportGoodMain : Form
    {
        private ImportGood importGood;
        public ItImportGoodMain(ImportGood importGood)
        {
            InitializeComponent();
            this.importGood = importGood;
        }

        private void ItImportGoodMain_Load(object sender, EventArgs e)
        {
            txtId.Text = importGood.Id;
            txtStaff.Text = importGood.Staff.Name;
            txtDate.Text = importGood.ImportTime.ToString("dd-MM-yyyy");
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            ImportGoodInfoFrm f = new ImportGoodInfoFrm(importGood);
            f.ShowDialog();
        }
    }
}
