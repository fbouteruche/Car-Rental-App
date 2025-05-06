using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.Shared;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Employees
{
    public partial class EmployeeTableControl : UserControl
    {
        public EmployeeTableControl()
        {
            InitializeComponent();
            gridEmployees.ConfigureZebraGrid();
            gridEmployees.ConfigureReadOnlyGrid();
            gridEmployees.Columns.AddRange(GetColumns());
        }
        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Phone", HeaderText = "Phone"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn {DataPropertyName = "InternalRegistration", HeaderText = "Internal Registration"},

                new DataGridViewTextBoxColumn {DataPropertyName = "LoginUsername", HeaderText = "Username"},

                new DataGridViewTextBoxColumn {DataPropertyName = "JobTitle", HeaderText = "Job Title"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Salary", HeaderText = "Salary"},

                new DataGridViewTextBoxColumn {DataPropertyName = "HiringDate", HeaderText = "Hiring Date"}
           };

            return columns;
        }

        public int GetSelectedId()
        {
            return gridEmployees.SelectId<int>();
        }

        public void UpdateRecords(List<Domain.EmployeeModule.Employee> employees)
        {
            gridEmployees.Rows.Clear();

            foreach (Domain.EmployeeModule.Employee employee in employees)
            {
                gridEmployees.Rows.Add(employee.Id, employee.Name, employee.UniqueId,
                    employee.Address, employee.Phone, employee.Email, employee.InternalRegistration,
                    employee.LoginUsername, employee.JobTitle, employee.Salary, employee.HiringDate);
            }
        }
    }
}
