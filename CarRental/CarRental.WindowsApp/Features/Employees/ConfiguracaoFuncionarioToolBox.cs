using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Funcionarios
{
    public class ConfiguracaoFuncionarioToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro { get { return "Cadastro de Funcionários"; } }

        public string ToolTipAdicionar { get { return "Adicionar um Funcionário"; } }

        public string ToolTipEditar { get { return "Edit um Funcionário"; } }

        public string ToolTipExcluir { get { return "Delete um Funcionário"; } }
    }
}
