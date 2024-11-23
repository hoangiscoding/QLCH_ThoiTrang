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
    public partial class RegisterFrm : Form
    {
        private CommonController commonController = new CommonController();
        private StaffController staffController = new StaffController();
        List<String> usernames;
        List<String> emails;
        List<String> phones;
        List<Staff> staffs;
        string avatarPath;
        public RegisterFrm()
        {
            InitializeComponent();
            Initialize();
            CenterToParent();
        }

        private void Initialize()
        {
            avatarPath = commonController.GetDefaultAvatarPath();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn thoát?";
            var caption = "Thông báo";
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void txtAccount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAccount.Text == "Tên đăng nhập:")
                txtAccount.Text = "";
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

        private string[] predefinedImagePaths = { "D:\\DH\\Kì 5\\LTTQ\\BTL\\QLShopThoiTrang\\images\\Avatars\\man.png", "D:\\DH\\Kì 5\\LTTQ\\BTL\\QLShopThoiTrang\\images\\Avatars\\woman.png" };

        private void btnAddAvatar_Click(object sender, EventArgs e)
        {
            SelectImageFrm selectImageForm = new SelectImageFrm("D:\\DH\\Kì 5\\LTTQ\\BTL\\QLShopThoiTrang\\images\\Avatars\\man.png",
                "D:\\DH\\Kì 5\\LTTQ\\BTL\\QLShopThoiTrang\\images\\Avatars\\woman.png");
            selectImageForm.ShowDialog();

            string selectedImagePath = selectImageForm.GetSelectedImagePath();
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                pictureAvatar.Image = new Bitmap(selectedImagePath);
                avatarPath = selectedImagePath;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool success = true;
            CheckInputController check = new CheckInputController();
            usernames = commonController.LoadAllUsername();
            emails = commonController.LoadAllEmail();
            phones = commonController.LoadAllPhoneNumber();
            string username = txtAccount.Text;
            string password = txtPassword.Text;
            string name = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            string gender = "Khác";
            DateTime birthDate = dateTimePickerBirthDate.Value;

            if (comboGender.SelectedIndex < 0)
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
                MessageBox.Show("Username đã tồn tại!");
                success = false;
            }
            else if (!check.IsPasswordValid(password))
            {
                MessageBox.Show("Thông tin password không hợp lệ!");
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
                gender = comboGender.SelectedItem.ToString();
                if (gender == "Nữ")
                    avatarPath = "D:\\DH\\Kì 5\\LTTQ\\BTL\\QLShopThoiTrang\\images\\Avatars\\woman.png";
            }

            if (success)
            {
                string role = staffs.Count == 0 ? "QUẢN LÝ" : "NHÂN VIÊN";

                var currId = staffController.GetCurrId(staffs);
                Staff staff = new Staff(++currId, username, password, name, gender,
                    birthDate, phone, email, address, avatarPath, role);

                staffController.CreateNewStaff(staff);

                MessageBox.Show("Đăng ký thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }
        }

        private void RegisterFrm_Load(object sender, EventArgs e)
        {
            usernames = commonController.LoadAllUsername();
            staffs = staffController.LoadAllStaff();
        }
    }
}
