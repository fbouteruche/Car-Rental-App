using CarRental.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.PartnerModule
{
    public class Partner : BaseEntity
    {
        public string Nome { get; }

        public Partner(int id, string name)
        {
            Id = id;
            Nome = name;
        }

        public override string Validate()
        {
            string validationResult = "";

            if (string.IsNullOrEmpty(Nome))
                validationResult += "The Name field is required";
            if (validationResult == "")
                validationResult = "VALID";

            return validationResult;
        }

        public override bool Equals(object obj)
        {
            return obj is Partner comparerdPartner &&
                   Id == comparerdPartner.Id &&
                   Nome == comparerdPartner.Nome;
        }

        public override int GetHashCode()
        {
            int hashCode = -1643562096;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }

        public override string ToString()
        {
            return $" {id}, {Nome}";
        }
    }
}
