using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controllers;
namespace Views
{
    public partial class ItPanelSetting : Form
    {
        string avatarPath;
        Staff Staff { get; set; }
        CommonController commonController = new CommonController();
        StaffController staffController = new StaffController();
        private HomeFrm parentFrm;
        public ItPanelSetting(HomeFrm parent, Staff staff)
        {
            this.Staff = staff;
            avatarPath = Staff.AvatarPath;
            parentFrm = parent;
            InitializeComponent();
        }

        private void txtAccount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Tên đăng nhập:")
                txtUsername.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu:")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtFullName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtFullName.Text == "Họ và tên:")
                txtFullName.Text = "";
        }

        private void txtPhoneNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPhoneNumber.Text == "Số điện thoại:")
                txtPhoneNumber.Text = "";
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.Text == "Email:")
                txtEmail.Text = "";
        }

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAddress.Text == "Địa chỉ:")
                txtAddress.Text = "";
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            SelectImageFrm selectImageForm = new SelectImageFrm("D:\\HatiStore\\images\\Avatars\\man.png",
                "D:\\HatiStore\\images\\Avatars\\woman.png");
            selectImageForm.ShowDialog();

            string selectedImagePath = selectImageForm.GetSelectedImagePath();
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                pictureAvatar.Image = new Bitmap(selectedImagePath);
                avatarPath = selectedImagePath;
            }
        }
        //Load các thông tin sẵn có của tài khoản
        private void ItPanelSetting_Load(object sender, EventArgs e)
        {
            pictureAvatar.Image = Image.FromFile(Staff.AvatarPath);
            txtFullName.Text = Staff.Name;
            if (Staff.Gender == "Nam")
                comboGender.SelectedIndex = 0;
            else if (Staff.Gender == "Nữ")
                comboGender.SelectedIndex = 1;
            dateTimePickerBirthDate.Value = Staff.BirthDate;
            txtPhoneNumber.Text = Staff.PhoneNumber;
            txtEmail.Text = Staff.Email;
            txtAddress.Text = Staff.Address;
            txtUsername.Text = Staff.Username;
            txtPassword.Text = Staff.Password;
            txtPassword.Enabled = false;
            txtPassword.PasswordChar = '*';
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            Staff.Name = txtFullName.Text;
            Staff.Email = txtEmail.Text;
            Staff.Address = txtAddress.Text;
            Staff.AvatarPath = avatarPath;
            if (comboGender.SelectedIndex == 0)
            {
                Staff.Gender = "Nam";
            }
            else
            {
                Staff.Gender = "Nữ";
            }
            Staff.BirthDate = dateTimePickerBirthDate.Value;
            Staff.PhoneNumber = txtPhoneNumber.Text;
            var res = MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin mới?",
                "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                staffController.EditStaffInfo(Staff);
                ChangeHandler(Staff);
                MessageBox.Show("Lưu thông tin nhân viên thành công");
            }
        }

        private void ChangeHandler(Staff staff)
        {
            parentFrm.ShowCommonInfo(staff);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm f = new ChangePasswordFrm(Staff);
            f.ShowDialog();
        }
    }
}
