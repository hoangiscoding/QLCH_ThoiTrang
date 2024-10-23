using Controllers;
using Models;
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

namespace Views
{
    public partial class StaffInfo_CreateFrm : Form
    {
        private CommonController commonController = new CommonController();
        private StaffController staffController = new StaffController();
        List<String> usernames;
        List<String> emails;
        List<String> phones;
        List<Staff> staffs;
        public Staff Staff { get; set; }

        //tạo form cập nhật
        public StaffInfo_CreateFrm(Staff staff)
        {
            InitializeComponent();
            staffs = staffController.LoadAllStaff();
            Staff = staff;
            txtStaffUsername.Enabled = false;
            FillData(staff);
        }
        //tạo form thêm mới
        public StaffInfo_CreateFrm()
        {
            InitializeComponent();
            staffs = staffController.LoadAllStaff();
            btnCreateUpdate.Text = "THÊM MỚI";
            btnResetPassword.Visible = false;
        }
        private void FillData(Staff staff)
        {
            txtStaffUsername.Text = staff.Username;
            txtStaffName.Text = staff.Name;
            txtStaffPhone.Text = staff.PhoneNumber;
            txtStaffAdress.Text = staff.Address;
            txtStaffEmail.Text = staff.Email;
            dateTimeStaffBirthDate.Value = staff.BirthDate;
            var role = staff.Role;
            var gender = staff.Gender;
            if (role == "NHÂN VIÊN")
                comboStaffRole.SelectedIndex = 0;
            else if (role == "QUẢN LÝ")
                comboStaffRole.SelectedIndex = 1;
            if (gender == "Nam")
                comboStaffGender.SelectedIndex = 0;
            else if (gender == "Nữ")
                comboStaffGender.SelectedIndex = 1;
        }
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCreateUpdate_Click(object sender, EventArgs e)
        {
            if (btnCreateUpdate.Text == "CẬP NHẬT")
            {
                UpdateStaffHandler();
            }
            else if (btnCreateUpdate.Text == "THÊM MỚI")
            {
                CreateNewStaffHandler();
            }
        }

        private void UpdateStaffHandler()
        {
            bool success = true;
            CheckInputController check = new CheckInputController();
            emails = commonController.LoadAllEmail();
            phones = commonController.LoadAllPhoneNumber();
            string username = txtStaffUsername.Text;
            string name = txtStaffName.Text;
            string email = txtStaffEmail.Text;
            string phone = txtStaffPhone.Text;
            string address = txtStaffAdress.Text;
            string gender = "Khác";
            string role;
            string avatarPath = Staff.AvatarPath;
            DateTime birthDate = dateTimeStaffBirthDate.Value;
            if (comboStaffRole.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                success = false;
            }
            else if (!check.IsNameValid(name))
            {
                MessageBox.Show("Họ và tên không hợp lệ!");
                success = false;
            }
            else if (!check.IsEmailValid(email))
            {
                MessageBox.Show("Email không hợp lệ!");
                success = false;
            }
            else if (email != Staff.Email)
            {
                if (check.IsEmailExist(email, emails))
                {
                    MessageBox.Show("Email đã tồn tại!");
                    success = false;
                }
            }
            else if (!check.IsPhoneValid(phone))
            {
                MessageBox.Show("SĐT không hợp lệ! Bắt đầu bằng 03,05,07,08,09 và có 10 chữ số");
                success = false;
            }
            else if (phone != Staff.PhoneNumber)
            {
                if (check.IsPhoneExist(phone, phones))
                {
                    MessageBox.Show("SĐT đã tồn tại!");
                    success = false;
                }
            }
            else
            {
                gender = comboStaffGender.SelectedItem.ToString();
            }
            role = comboStaffRole.SelectedItem.ToString();
            if (success)
            {
                Staff.Name = name;
                Staff.Gender = gender;
                Staff.Username = username;
                Staff.Address = address;
                Staff.Email = email;
                Staff.BirthDate = birthDate;
                Staff.Role = role;
                Staff.PhoneNumber = phone;
                staffController.EditStaffInfo(Staff);
                MessageBox.Show("Cập nhật thông tin thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại!");
            }
        }

        private void CreateNewStaffHandler()
        {
            bool success = true;
            CheckInputController check = new CheckInputController();
            usernames = commonController.LoadAllUsername();
            emails = commonController.LoadAllEmail();
            phones = commonController.LoadAllPhoneNumber();
            string username = txtStaffUsername.Text;
            string name = txtStaffName.Text;
            string email = txtStaffEmail.Text;
            string phone = txtStaffPhone.Text;
            string address = txtStaffAdress.Text;
            string gender = "Khác";
            
            DateTime birthDate = dateTimeStaffBirthDate.Value;
            if (comboStaffRole.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                success = false;
            }
            else if (!check.IsUsernameValid(username))
            {
                MessageBox.Show("Thông tin username không hợp lệ!");
                success = false;
            }
            else if (check.IsUsernameExist(username, usernames))
            {
                MessageBox.Show("username đã tồn tại!");
                success = false;
            }
            else if (!check.IsNameValid(name))
            {
                MessageBox.Show("Họ và tên không hợp lệ!");
                success = false;
            }
            else if (!check.IsEmailValid(email))
            {
                MessageBox.Show("Email không hợp lệ!");
                success = false;
            }
            else if (check.IsEmailExist(email, emails))
            {
                MessageBox.Show("Email đã tồn tại!");
                success = false;
            }
            else if (!check.IsPhoneValid(phone))
            {
                MessageBox.Show("SĐT không hợp lệ! Bắt đầu bằng 03,05,07,08,09 và có 10 chữ số");
                success = false;
            }
            else if (check.IsEmailExist(phone, phones))
            {
                MessageBox.Show("SĐT đã tồn tại!");
                success = false;
            }
            else
            {
                gender = comboStaffGender.SelectedItem.ToString();
            }
            string role = comboStaffRole.SelectedItem.ToString();
            string avatarPath = commonController.GetDefaultAvatarPath();
            if (success)
            {
                var currId = staffController.GetCurrId(staffs);
                Staff staff = new Staff(++currId, username, "123", name, gender,
                    birthDate, phone, email, address, avatarPath, role);
                staffController.CreateNewStaff(staff);
                MessageBox.Show("Đăng ký thành công! Mật khẩu mặc định là '123'");

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboStaffRole.SelectedIndex == 1)
            {
                MessageBox.Show("Không thể xoá quản lý",
                    "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                var res = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?",
                "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    staffController.RemoveStaff(staffs, txtStaffUsername.Text);
                    var removeStaff = staffController.FindStaffByUsername(txtStaffUsername.Text);
                    staffs.Remove(removeStaff);
                    ItPanelManage f = new ItPanelManage();
                    f.ItPanelManage_Load(this, null);
                    this.Dispose();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Mật khẩu cho tài khoản này là {Staff.Password}");
        }
    }
}
