using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Youtube.UygulamaAlani.CustomerApp.Core.Entities;
using Youtube.UygulamaAlani.CustomerApp.Core.Repositories;

namespace Youtube.UygulamaAlani.CustomerApp.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetCustomerList();
        }

        void GetCustomerList()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> dataItemList = customerRepository.GetDataList();
            lst_dataList.DataSource = dataItemList;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            int result = customerRepository.AddNewDataItem(new Customer()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                EmailAddress = txt_EmailAddress.Text,
                TelephoneNumber = txt_TelephoneNumber.Text,
                CreateDate = DateTime.Now
            });
            if (result != 0)
            {
                GetCustomerList();
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txt_EmailAddress.Text = string.Empty;
                txt_TelephoneNumber.Text = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lst_dataList.SelectedItem != null)
            {
                CustomerRepository customerRepository = new CustomerRepository();
                customerRepository.UpdateDataItem(new Customer()
                {
                    Id = ((Customer)lst_dataList.SelectedItem).Id,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    EmailAddress = txt_EmailAddress.Text,
                    TelephoneNumber = txt_TelephoneNumber.Text
                });
                GetCustomerList();
            }
        }

        private void lst_dataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer selectedCustomer = (Customer)lst_dataList.SelectedItem;
            txtFirstName.Text = selectedCustomer.FirstName;
            txtLastName.Text = selectedCustomer.LastName;
            txt_EmailAddress.Text = selectedCustomer.EmailAddress;
            txt_TelephoneNumber.Text = selectedCustomer.TelephoneNumber;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
           int result = customerRepository.DeleteDataItem(((Customer)lst_dataList.SelectedItem).Id);
            if (result > 0)
            {
                GetCustomerList();
            }
        }
    }
}
