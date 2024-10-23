using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Principal;
using Models;
namespace Views
{
    public partial class HomeFrm : Form
    {
        private Form currentPanelForm;
        public Staff Staff { get; set; }
        public HomeFrm(Staff staff)
        {
            Staff = staff;
            if (Staff.Role == "QUẢN LÝ")
            {
                InitializeComponent();
                FormManagerLoad(staff);
                CenterToParent();
            }
            else if (Staff.Role == "NHÂN VIÊN")
            {
                InitializeComponent();
                FormStaffLoad(staff);
                CenterToParent();
            }
        }

        private void SetChange(Staff staff)
        {
            txtName.Text = staff.Name;
            txtRole.Text = staff.Role;
            pictureAvatar.Image = Image.FromFile(staff.AvatarPath);
        }
        public void FormStaffLoad(Staff staff)
        {
            //Hiển thị các thông tin chung
            ShowCommonInfo(staff);

            //ẩn 2 nút thống kê, quản lý
            btnManage.Visible = false;

            //đẩy nút Setting lên trên
            btnSetting.Location = new Point(3, 463);

            //Hiển thị panel của home
            ShowPanelHome();
        }

        //những việc cần làm khi load trang lên
        public void FormManagerLoad(Staff staff)
        {
            ShowCommonInfo(staff);
            //Hiển thị panel của home
            ShowPanelHome();
        }

        //Hiển thị các thông tin chung của cả nhân viên và quản lý
        public void ShowCommonInfo(Staff staff)
        {
            txtName.Text = staff.Name;
            txtRole.Text = staff.Role;
            pictureAvatar.Image = Image.FromFile(staff.AvatarPath);
        }

        //Hiển thị panel của home
        private void ShowPanelHome()
        {
            ItPanelHome f = new ItPanelHome();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        //Sự kiện nút Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn thoát?";
            var caption = "Thông báo";
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelHome f = new ItPanelHome();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelBill f = new ItPanelBill();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }


        private void btnProduct_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelProduct f = new ItPanelProduct();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelCustomer f = new ItPanelCustomer();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        private void btnImportGood_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelImportGood f = new ItPanelImportGood();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelSetting f = new ItPanelSetting(this, Staff);
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        public void btnManage_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem trong Panel2 đã có Form nào chưa
            if (currentPanelForm != null && !currentPanelForm.IsDisposed)
            {
                currentPanelForm.Close();  // Đóng Form trước khi Dispose
                currentPanelForm.Dispose();
            }
            ItPanelManage f = new ItPanelManage();
            if (f.Parent != null)
            {
                f.Parent.Controls.Remove(f);
            }
            // Thiết lập TopLevel, Dock và Parent cho UserControl
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(f);
            f.Show();
            currentPanelForm = f;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
