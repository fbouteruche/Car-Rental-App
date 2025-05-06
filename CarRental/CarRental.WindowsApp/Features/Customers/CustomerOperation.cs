using CarRental.Controllers.CustomersModule;
using CarRental.Domain.CustomerModule;
using CarRental.WindowsApp.CustomerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Customers
{
    public class CustomerOperation : IRecordable
    {
        private readonly CustomerController controller = null;
        private readonly CustomerTableControl customerTable = null;
        public CustomerOperation(CustomerController customerController)
        {
            controller = customerController;
            customerTable = new CustomerTableControl();
        }

        public void EditRecord()
        {
            int id = customerTable.GetSelectedId();
            if (id == 0)
            {
                MessageBox.Show("Select a customer to edit", "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Customer selectedCustomer = controller.SelectById(id);
            CustomerForm form = new CustomerForm("Edit Customer");
            form.CustomerData = selectedCustomer;
            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.CustomerData);
                List<Customer> customers = controller.SelectAll();
                customerTable.UpdateRecords();
                MainForm.Instance.UpdateFooter($"Customer: [{form.CustomerData.Name}] successfully edited");
            }
        }
        public void DeleteRecord()
        {
            int id = customerTable.GetSelectedId();
            if (id == 0)
            {
                MessageBox.Show("Select a customer to delete", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Customer selectedCustomer = controller.SelectById(id);
            if (MessageBox.Show($"Are you sure you want to delete the customer: [{selectedCustomer.Name}] ?",
                "Delete Customer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);
                List<Customer> customers = controller.SelectAll();
                customerTable.UpdateRecords();
                MainForm.Instance.UpdateFooter($"Customer: [{selectedCustomer.Name}] successfully removed");
            }
        }
        public void InsertNewRecord()
        {
            CustomerForm form = new CustomerForm("Customer Registration");
            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.CustomerData);
                List<Customer> customers = controller.SelectAll();
                customerTable.UpdateRecords();
                MainForm.Instance.UpdateFooter($"Customer: [{form.CustomerData.Name}] successfully added");
            }
        }

        public UserControl GetTable()
        {
            List<Customer> customers = controller.SelectAll();
            customerTable.UpdateRecords();
            return customerTable;
        }
        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }
    }
}
