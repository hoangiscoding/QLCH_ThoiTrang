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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Views
{
    public partial class ItPanelCustomer : Form
    {
        private List<Customer> customers = new List<Customer>();
        private CustomerController customerController = new CustomerController();
        public ItPanelCustomer()
        {
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            customers = customerController.LoadAllCustomer();
        }

        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            CustomerInfo_CreateFrm f = new CustomerInfo_CreateFrm();
            f.ShowDialog();
        }

        private void ItPanelCustomer_Load(object sender, EventArgs e)
        {
            RemoveAll();
            foreach (var customer in customers)
            {
                ItCustomerInfo f = new ItCustomerInfo(customer);
                f.TopLevel = false;
                flowPanelCustomer.Controls.Add(f);
                f.Show();
            }
        }

        private void RemoveAll()
        {
            flowPanelCustomer.Controls.Clear();
        }

        private void txtCustomerFind_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCustomerFind.Text == "Tìm kiếm:")
                txtCustomerFind.Text = "";
        }

        private void txtCustomerFind_TextChanged(object sender, EventArgs e)
        {
            string criteria = "";
            string content = txtCustomerFind.Text;
            if (string.IsNullOrEmpty(content))
            {
                // Clear the customer list if the search box is empty
                customers = customerController.LoadAllCustomer();
                ItPanelCustomer_Load(this, null);
                return;
            }
            switch (comboCustomerFind.SelectedIndex)
            {
                case 0:
                    criteria = "Find By Name";
                    break;
                case 1:
                    criteria = "Find By Id";
                    break;
                case 2:
                    criteria = "Find By PhoneNumber";
                    break;
            }
            switch (criteria)
            {
                case "Find By Name":
                    {
                        if (content != "")
                        {
                            customers = customerController.FindCustomerByName(content, "Customer");
                            ItPanelCustomer_Load(this, null);
                        }
                        break;
                    }
                case "Find By Id":
                    {
                            if (content != "")
                            {
                                customers = customerController.FindCustomerById(content, "Customer");
                                ItPanelCustomer_Load(this, null);
                            }
                        break;
                    }
                case "Find By PhoneNumber":
                    {
                        if (content != "")
                        {
                            customers = customerController.FindCustomerByPhoneNumber(content, "Customer");
                            ItPanelCustomer_Load(this, null);
                        }
                        break;
                    }
            }
            ItPanelCustomer_Load(this, null);

        }
    }
}
