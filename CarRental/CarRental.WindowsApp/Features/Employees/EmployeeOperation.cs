using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Controllers.EmployeeModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.Shared;
using CarRental.Domain.PersonModule;
using CarRental.Controllers.Shared;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Features.Employee;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Employees
{
    public class EmployeeOperation : IRecordable
    {
        private readonly EmployeeController controller = null;
        private readonly EmployeeTableControl employeeTable = null;

        public EmployeeOperation(EmployeeController employeeController)
        {
            controller = employeeController;
            employeeTable = new EmployeeTableControl();
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void EditRecord()
        {
            int id = employeeTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select an employee to edit!", "Employee Editing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Domain.EmployeeModule.Employee selectedEmployee = controller.SelectById(id);
            EmployeeForm form = new EmployeeForm("Edit Employee");
            form.Employee = selectedEmployee;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Employee);
                List<Domain.EmployeeModule.Employee> employees = controller.SelectAll();
                employeeTable.UpdateRecords(employees);
                MainForm.Instance.UpdateFooter($"Employee: [{selectedEmployee.Name}] successfully edited");
            }
        }

        public void DeleteRecord()
        {
            int id = employeeTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select an employee to delete", "Employee Deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Domain.EmployeeModule.Employee selectedEmployee = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the employee: [{selectedEmployee.Name}] ?", "Employee Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controller.Delete(id);
                List<Domain.EmployeeModule.Employee> employees = controller.SelectAll();
                employeeTable.UpdateRecords(employees);
                MainForm.Instance.UpdateFooter($"Employee: [{selectedEmployee.Name}] successfully removed");
            }
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void InsertNewRecord()
        {
            EmployeeForm form = new EmployeeForm("Employee Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.Employee);
                List<Domain.EmployeeModule.Employee> employees = controller.SelectAll();
                employeeTable.UpdateRecords(employees);
                MainForm.Instance.UpdateFooter($"Employee: [{form.Employee.Name}] successfully added");
            }
        }

        public UserControl GetTable()
        {
            List<Domain.EmployeeModule.Employee> employees = controller.SelectAll();
            employeeTable.UpdateRecords(employees);
            return employeeTable;
        }
    }
}
