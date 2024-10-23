using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class LoginFrm : Form
    {
        CommonController commonController = new CommonController();
        StaffController staffController = new StaffController();
        public LoginFrm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            var msg = "Bạn có chắc chắn muốn thoát?";
            var caption = "Thông báo";
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void txtAccount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAccount.Text == "TÊN ĐĂNG NHẬP:")
                txtAccount.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "MẬT KHẨU:")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role;
            if (checkBoxManager.Checked)
            {
                role = "QUẢN LÝ";
            }
            else
                role = "NHÂN VIÊN";
            var staff = staffController.CheckLogin(txtAccount.Text, txtPassword.Text, role);
            if (staff != null)
            {
                HomeFrm f = new HomeFrm(staff);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!",
                    "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void txtRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterFrm frm = new RegisterFrm();
            frm.ShowDialog();
        }

        private void txtForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản lý để lấy lại mật khẩu!");
        }


    }
}
