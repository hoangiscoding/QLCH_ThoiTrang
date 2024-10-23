using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
namespace Views
{
    public partial class CustomerInfo_CreateFrm : Form
    {
        CustomerController cusController = new CustomerController();
        CommonController commonController = new CommonController();
        CheckInputController checkInputController = new CheckInputController();
        List<Customer> customers;
        List<String> emails;
        List<String> phones;
        int currId;
        private Customer Customer { get; set; }

        //form cập nhật
        public CustomerInfo_CreateFrm(Customer customer)
        {
            InitializeComponent();
            CenterToParent();
            LoadInfo(customer);
            Customer = customer;
            txtRank.Enabled = false;
            txtCustomerId.Enabled = false;
            txtTotalAmount.Enabled = false;
            btnCreateUpdate.Text = "CẬP NHẬT";
        }

        //form thêm mới
        public CustomerInfo_CreateFrm()
        {
            InitializeComponent();
            CenterToParent();
            customers = cusController.LoadAllCustomer();
            txtTotalAmount.Text = "0";
            currId = cusController.GetCurrId(customers) + 1;
            txtCustomerId.Text = "KH" + currId;
            txtTotalAmount.Enabled = false;
            txtRank.Enabled = false;
            btnCreateUpdate.Text = "THÊM MỚI";
            txtRank.Text = "ĐỒNG";
        }

        private void LoadInfo(Customer customer)
        {
            txtCustomerId.Text = customer.Id;
            txtCustomerName.Text = customer.Name;
            txtCustomerPhone.Text = customer.PhoneNumber;
            txtEmail.Text = customer.Email;
            txtAddress.Text = customer.Address;
            txtRank.Text = customer.Rank;
            txtTotalAmount.Text = customer.Revenue.ToString();
            if (customer.Gender == "Nam")
            {
                comboCustomerGender.SelectedIndex = 0;
            }
            else if (customer.Gender == "Nữ")
            {
                comboCustomerGender.SelectedIndex = 1;
            }
            else { comboCustomerGender.SelectedIndex = -1; }
            dateTimeBirthDate.Value = customer.BirthDate;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            emails = commonController.LoadAllEmail();
            phones = commonController.LoadAllPhoneNumber();

            var id = txtCustomerId.Text;
            var name = txtCustomerName.Text;
            var phone = txtCustomerPhone.Text;
            var gender = "Khác";
            if (comboCustomerGender.SelectedIndex == 0)
            {
                gender = "Nam";
            }
            else if (comboCustomerGender.SelectedIndex == 1)
            {
                gender = "Nữ";
            }
            var email = txtEmail.Text;
            var birthDate = dateTimeBirthDate.Value;
            int totalAmount = int.Parse(txtTotalAmount.Text);
            var rank = txtRank.Text;
            var address = txtAddress.Text;
            if (btnCreateUpdate.Text == "CẬP NHẬT")
            {
                UpdateCustomer(id, name, phone, gender, email, birthDate, totalAmount, rank, address);
                this.Dispose();
            }
            else if (btnCreateUpdate.Text == "THÊM MỚI")
            {
                RegisterCusomer(id, name, phone, gender, email, birthDate, totalAmount, rank, address);
                this.Dispose();
            }
        }

        /// <summary>
        /// Chức năng thêm mới khách hàng
        /// </summary>
        private void RegisterCusomer(string id, string name, string phone,
            string gender, string email, DateTime birthDate, int totalAmount,
            string rank, string address)
        {
            bool success = true;
            if (!checkInputController.IsNameValid(name))
            {
                success = false;
                MessageBox.Show("Tên không hợp lệ.");
            }
            else if (!checkInputController.IsEmailValid(email))
            {
                success = false;
                MessageBox.Show("Email không hợp lệ.");
            }
            else if (checkInputController.IsEmailExist(email, emails))
            {
                MessageBox.Show("Email đã tồn tại!");
                success = false;
            }
            else if (!checkInputController.IsPhoneValid(phone))
            {
                success = false;
                MessageBox.Show("SĐT không hợp lệ.");
            }
            else if (checkInputController.IsEmailExist(phone, phones))
            {
                MessageBox.Show("SĐT đã tồn tại!");
                success = false;
            }
            else if (comboCustomerGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                success = false;
            }
            if (success)
            {
                Customer customer = new Customer(id, "", "", name, gender,
                    birthDate, phone, email, address, "", totalAmount, rank);
                cusController.CreateNewCustomer(customer);
                MessageBox.Show("Đăng ký thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }

        }

        /// <summary>
        /// Chức năng sửa thông tin khách hàng
        /// </summary>
        private void UpdateCustomer(string id, string name, string phone,
            string gender, string email, DateTime birthDate, int totalAmount,
            string rank, string address)
        {
            bool success = true;
            if (!checkInputController.IsNameValid(name))
            {
                success = false;
                MessageBox.Show("Tên không hợp lệ.");
            }
            else if (!checkInputController.IsEmailValid(email))
            {
                success = false;
                MessageBox.Show("Email không hợp lệ.");
            }
            else if (email != Customer.Email)
            {
                if (checkInputController.IsEmailExist(email, emails))
                {
                    MessageBox.Show("Email đã tồn tại!");
                    success = false;
                }
            }
            else if (!checkInputController.IsPhoneValid(phone))
            {
                success = false;
                MessageBox.Show("SĐT không hợp lệ.");
            }
            else if (phone != Customer.PhoneNumber)
            {
                if (checkInputController.IsEmailExist(phone, phones))
                {
                    MessageBox.Show("SĐT đã tồn tại!");
                    success = false;
                }
            }
            else if (comboCustomerGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                success = false;
            }
            if (success)
            {
                Customer.Name = name;
                Customer.PhoneNumber = phone;
                Customer.Gender = gender;
                Customer.Email = email;
                Customer.BirthDate = birthDate;
                Customer.Address = address;
                cusController.EditCustomerInfo(Customer);
                MessageBox.Show("Cập nhật thông tin thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại!");
            }
        }
    }
}
