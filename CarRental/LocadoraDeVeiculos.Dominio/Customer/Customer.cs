using CarRental.Domain.PessoaModule;
using System;
using System.Collections.Generic;

namespace CarRental.Domain.ClienteModule
{
    public class Customer : Person
    {
        public string DriverLicense { get; }
        public DateTime? LicenseExpiryDate { get; }

        public Customer(int id, string nome, string registroUnico, string endereco, string telefone, string email, string cnh, DateTime? validadeCnh, bool ehPessoaFisica)
        {
            this.id = id;
            Name = nome;
            UniqueId = registroUnico;
            Address = endereco;
            Phone = telefone;
            Email = email;
            DriverLicense = cnh;
            LicenseExpiryDate = validadeCnh;
            IsPhysicalPerson = ehPessoaFisica;
        }

        public override string Validate()
        {
            string validationResult = "";
            if (IsPhysicalPerson)
            {
                if (!ValidateDriverLicense())
                    validationResult += "Invalid Driver's License\n";
                if (LicenseExpiryDate < DateTime.Now)
                    validationResult += "Driver's License expired\n";
            }
            if (base.ValidatePerson() != "VALID")
                validationResult += base.ValidatePerson();
            if (validationResult == "")
                validationResult = "VALID";
            return validationResult;
        }

        public bool ValidateDriverLicense()
        {
            bool isValid = false;
            var selectedLicense = this.DriverLicense;
            selectedLicense = this.DriverLicense.Replace(".", "").Replace("-", "").Replace(",", "");
            if (selectedLicense.Length < 11)
                return false;
            var firstChar = selectedLicense[0];
            if (selectedLicense.Length == 11 && selectedLicense != new string('1', 11))
            {
                var dsc = 0;
                var v = 0;
                for (int i = 0, j = 9; i < 9; i++, j--)
                    v += (Convert.ToInt32(selectedLicense[i].ToString()) * j);

                var vl1 = v % 11;
                if (vl1 >= 10)
                {
                    vl1 = 0;
                    dsc = 2;
                }

                v = 0;
                for (int i = 0, j = 1; i < 9; ++i, ++j)
                    v += (Convert.ToInt32(selectedLicense[i].ToString()) * j);

                var x = v % 11;
                var vl2 = (x >= 10) ? 0 : x - dsc;

                isValid = vl1.ToString() + vl2.ToString() == selectedLicense.Substring(selectedLicense.Length - 2, 2);
            }
            return isValid;
        }

        public override string ToString()
        {
            return $"Customer = [{id}, {Name}, {UniqueId}, {Address}, {Phone}, {Email}, {DriverLicense}, {LicenseExpiryDate}, {IsPhysicalPerson}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Customer cliente &&
                   id == cliente.id &&
                   Name == cliente.Name &&
                   UniqueId == cliente.UniqueId &&
                   Address == cliente.Address &&
                   Phone == cliente.Phone &&
                   Email == cliente.Email &&
                   IsPhysicalPerson == cliente.IsPhysicalPerson &&
                   DriverLicense == cliente.DriverLicense &&
                   LicenseExpiryDate == cliente.LicenseExpiryDate;
        }

        public override int GetHashCode()
        {
            int hashCode = -1382064342;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + IsPhysicalPerson.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DriverLicense);
            hashCode = hashCode * -1521134295 + LicenseExpiryDate.GetHashCode();
            return hashCode;
        }
    }
}
