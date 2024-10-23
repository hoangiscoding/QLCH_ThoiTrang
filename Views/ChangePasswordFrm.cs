using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Net.Mime.MediaTypeNames;

namespace Views
{
    public partial class ChangePasswordFrm : Form
    {
        private Staff Staff { get; set; }
        private StaffController staffController = new StaffController();
        public ChangePasswordFrm(Staff staff)
        {
            InitializeComponent();
            CenterToParent();
            this.Staff = staff;
        }

        private void checkBoxShowOldPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowOldPassword.Checked)
            {
                txtOldPassword.PasswordChar = '\0';
            }
            else
            {
                txtOldPassword.PasswordChar = '*';
            }
        }

        private void checkBoxShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowNewPassword.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
            }
        }

        private void checkBoxShowNewPasswordAgain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowNewPasswordAgain.Checked)
            {
                txtNewPasswordAgain.PasswordChar = '\0';
            }
            else
            {
                txtNewPasswordAgain.PasswordChar = '*';
            }
        }

        private void txtOldPassword_MouseClick(object sender, MouseEventArgs e)
        {
            ChangedText(txtOldPassword.Text, "MẬT KHẨU CŨ:", txtOldPassword);
        }

        private void txtNewPassword_MouseClick(object sender, MouseEventArgs e)
        {
            ChangedText(txtNewPassword.Text, "MẬT KHẨU MỚI:", txtNewPassword);
        }

        private void txtNewPasswordAgain_MouseClick(object sender, MouseEventArgs e)
        {
            ChangedText(txtNewPasswordAgain.Text, "NHẬP LẠI MẬT KHẨU:", txtNewPasswordAgain);
        }
        private void ChangedText(string text, string target, TextBox textBox)
        {
            if (text == target)
            {
                textBox.Text = "";
                textBox.PasswordChar = '*';
            }
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            CheckInputController inputController = new CheckInputController();
            if (CheckOldPasswordCorrect(txtOldPassword.Text))
            {
                if (inputController.IsPasswordValid(txtNewPassword.Text))
                {
                    if (txtNewPassword.Text.CompareTo(txtNewPasswordAgain.Text) == 0)
                    {
                        Staff.Password = txtNewPassword.Text;
                        staffController.EditStaffPassword(Staff);
                        MessageBox.Show("Thay đổi mật khẩu thành công!");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không trùng khớp. Vui lòng xem lại");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không hợp lệ. Vui lòng xem lại");
                }
            }
            else
            {
                var msg = "Mật khẩu cũ không chính xác";
                var caption = "Thông báo";
                MessageBox.Show(msg, caption,
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
        private bool CheckOldPasswordCorrect(string oldPassword)
        {
            return Staff.Password.CompareTo(oldPassword) == 0;
        }
    }
}
