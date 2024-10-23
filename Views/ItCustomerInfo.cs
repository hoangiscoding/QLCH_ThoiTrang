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
namespace Views
{
    public partial class ItCustomerInfo : Form
    {
        public Customer Customer { get; set; }
        public ItCustomerInfo(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
        }


        private void ItCustomerInfo_Load(object sender, EventArgs e)
        {
            txtId.Text = Customer.Id;
            txtName.Text = Customer.Name;
            txtAddress.Text = Customer.Address;
            txtPhone.Text = Customer.PhoneNumber;
        }

        private void panelPerson_MouseClick(object sender, MouseEventArgs e)
        {
            CustomerInfo_CreateFrm f = new CustomerInfo_CreateFrm(Customer);
            f.ShowDialog();
        }
    }
}
