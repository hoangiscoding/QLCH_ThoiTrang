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
    public partial class ItPanelManage : Form
    {
        private List<Staff> staffs = new List<Staff>();
        private StaffController staffController = new StaffController();
        public ItPanelManage()
        {
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            staffs = staffController.LoadAllStaff();
        }

        private void btnStaffCreate_Click(object sender, EventArgs e)
        {
            StaffInfo_CreateFrm f = new StaffInfo_CreateFrm();
            f.ShowDialog();
        }

        public void ItPanelManage_Load(object sender, EventArgs e)
        {
            RemoveAll();
            foreach (var staff in staffs)
            {
                ItStaffInfo f = new ItStaffInfo(staff);
                f.TopLevel = false;
                flowPanelStaff.Controls.Add(f);
                f.Show();
            }
        }

        private void RemoveAll()
        {
            foreach (Control control in flowPanelStaff.Controls)
            {
                if (control is ItStaffInfo itStaff)
                {
                    // Giải phóng tài nguyên của các hình ảnh trong control ItStaffInfo
                    itStaff.Dispose();
                }
            }
            flowPanelStaff.Controls.Clear();
        }

        private void txtStaffFind_TextChanged(object sender, EventArgs e)
        {
            string criteria = "";
            string content = txtStaffFind.Text;
            switch (comboStaffFind.SelectedIndex)
            {
                case 0:
                    criteria = "Find By Name";
                    break;
                case 1:
                    criteria = "Find By BirthDate";
                    break;
                case 2:
                    criteria = "Find By Gender";
                    break;
                case 3:
                    criteria = "Find By Username";
                    break;
                case 4:
                    criteria = "Find By Role";
                    break;
            }
            switch (criteria)
            {
                case "Find By Name":
                    {
                        staffs = staffController.FindStaffByName(content, "Staff");
                        ItPanelManage_Load(this, null);
                        break;
                    }
                case "Find By BirthDate":
                    {
                        staffs = staffController.FindStaffByBirthDate(content, "Staff");
                        ItPanelManage_Load(this, null);
                        break;
                    }
                case "Find By Gender":
                    {
                        staffs = staffController.FindStaffByGender(content, "Staff");
                        ItPanelManage_Load(this, null);
                        break;
                    }
                case "Find By Username":
                    {
                        staffs = staffController.FindStaffByUsername(content, "Staff");
                        ItPanelManage_Load(this, null);
                        break;
                    }
                case "Find By Role":
                    {
                        staffs = staffController.FindStaffByRole(content, "Staff");
                        ItPanelManage_Load(this, null);
                        break;
                    }

            }
        }

        private void txtStaffFind_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtStaffFind.Text == "Tìm kiếm:")
                txtStaffFind.Text = "";
        }
    }
}
