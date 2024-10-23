using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controllers;
namespace Views
{
    public partial class ItPanelBill : Form
    {
        List<Bill> bills = new List<Bill>();
        BillController billController = new BillController();
        public ItPanelBill()
        {
            InitializeComponent();
            CenterToParent();
            bills = billController.LoadAllBill();
        }

        private void txtBillFind_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBillFind.Text == "Tìm kiếm:")
                txtBillFind.Text = "";
        }

        private void btnBillCreate_Click(object sender, EventArgs e)
        {
            BillCreateFrm f = new BillCreateFrm();
            f.ShowDialog();
        }

        private void ItPanelBill_Load(object sender, EventArgs e)
        {
            flowPanelBill.Controls.Clear();
            foreach (var bill in bills)
            {
                ItBillInfoMain f = new ItBillInfoMain(bill);
                f.TopLevel = false;
                flowPanelBill.Controls.Add(f);
                f.Show();
            }
        }

        private void txtBillFind_TextChanged(object sender, EventArgs e)
        {
            switch (comboBillFind.SelectedIndex)
            {
                case 0:
                    {
                        //tìm theo mã HĐ
                        bills = billController.FindBillById(txtBillFind.Text);
                        ItPanelBill_Load(this, null);
                        break;
                    }
                case 1:
                    {
                        //Tìm theo tên KH
                        bills = billController.FindBillByCustomerName(txtBillFind.Text);
                        ItPanelBill_Load(this, null);
                        break;
                    }
                case 2:
                    {
                        //Tìm theo ngày
                        bills = billController.FindBillByDate(txtBillFind.Text);
                        ItPanelBill_Load(this, null);
                        break;
                    }

            }
        }
    }
}
