using CarRental.Domain.RentalModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.RentalServiceRelationshipModule
{
    public class RentalServiceRelationship : BaseEntity
    {
        public RentalModule.Rental Rental { get; }
        public List<Service> Services { get; }

        public RentalServiceRelationship(int id, RentalModule.Rental locacao, List<Service> servicos)
        {
            this.Id = id;
            Rental = locacao;
            Services = servicos;
        }

        public override string Validate()
        {
            string resultadoValidacao = "";
            if (Rental.Id == 0)
                resultadoValidacao = "ID de locação inválido";
            if (Services == null)
                resultadoValidacao = "Nenhum serviço selecionado";
            if (resultadoValidacao == "")
                resultadoValidacao = "VALIDO";
            return resultadoValidacao;
        }

        public override int GetHashCode()
        {
            int hashCode = 1438320420;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Rental>.Default.GetHashCode(Rental);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Service>>.Default.GetHashCode(Services);
            return hashCode;
        }
        public override string ToString()
        {
            return $"{id} {Rental} {Services}";
        }

        public override bool Equals(object obj)
        {
            return obj is RentalServiceRelationship serv &&
                   Id == serv.Id &&
                   EqualityComparer<Rental>.Default.Equals(Rental, serv.Rental) &&
                   EqualityComparer<List<Service>>.Default.Equals(Services, serv.Services);
        }
    }
}
