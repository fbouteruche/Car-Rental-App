using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Employees
{
    public class EmployeeConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType { get { return "Cadastro de Funcionários"; } }

        public string AddToolTip { get { return "Adicionar um Funcionário"; } }

        public string EditToolTip { get { return "Edit um Funcionário"; } }

        public string DeleteToolTip { get { return "Delete um Funcionário"; } }
    }
}
