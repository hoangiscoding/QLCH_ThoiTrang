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
    public partial class ItStaffInfo : Form
    {
        private Staff Staff { get; set; }
        public ItStaffInfo(Staff staff)
        {
            Staff = staff;
            InitializeComponent();
        }

        private void panelStaff_MouseClick(object sender, MouseEventArgs e)
        {
            StaffInfo_CreateFrm f = new StaffInfo_CreateFrm(Staff);
            f.ShowDialog();
        }

        private void ItStaffInfo_Load(object sender, EventArgs e)
        {
            txtFullName.Text = Staff.Name;
            txtPhone.Text = Staff.PhoneNumber;
            txtAddress.Text = Staff.Address;
            pictureAvatar.Image = Image.FromFile(Staff.AvatarPath);
        }
        
    }
}
