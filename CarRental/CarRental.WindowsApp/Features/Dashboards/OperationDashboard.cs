using CarRental.Controllers.VehicleModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public class OperationDashboard
    {
        private readonly VehicleController controladorVeiculo = null;
        //private readonly ControladorLocacao controladorLocacao = null;
        //private readonly DashboardControl dashboardControl = null;

        public OperationDashboard(VehicleController controladorVeiculo) //ControladorLocacao controladorLocacao)
        {
            //this.controladorLocacao = controladorLocacao;
            this.controladorVeiculo = controladorVeiculo;
            //dashboardControl = new DashboardControl();
        }
    }
}
