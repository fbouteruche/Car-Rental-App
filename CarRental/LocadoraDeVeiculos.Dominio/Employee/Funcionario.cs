using CarRental.Domain.PessoaModule;
using System;
using System.Collections.Generic;

namespace CarRental.Domain.FuncionarioModule
{
    public class Funcionario : Person
    {
        public int MatriculaInterna { get; }
        public string UsuarioAcesso { get; }
        public DateTime DataAdmissao { get; }
        public string Cargo { get; }
        public double Salario { get; }

        public string Senha { get; }

        public Funcionario(int id, string nome, string registroUnico, string endereco, string telefone, string email, int matriculaInterna, string usuarioAcesso,string senha, DateTime dataAdmissao, string cargo, double salario,bool ehPessoaFisica)
        {
            this.id = id;
            Name = nome;
            UniqueId = registroUnico;
            Address = endereco;
            Phone = telefone;
            Email = email;
            IsPhysicalPerson = true;
            MatriculaInterna = matriculaInterna;
            UsuarioAcesso = usuarioAcesso;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Cargo = cargo;
            Salario = salario;
            IsPhysicalPerson = ehPessoaFisica;
        }

        public override string Validate()
        {
            string resultadoValidação = "";
            if (UsuarioAcesso.Length == 0)
                resultadoValidação += "O usuário de acesso não pode estar vazio\n";
            if(MatriculaInterna <= 0)
                resultadoValidação += "Matricula inválida\n";
            if (Salario <= 0)
                resultadoValidação += "O salário deve ser maior que R$ 0,00\n";
            if(Cargo.Length == 0)
                resultadoValidação += "O funcionário deve possuir um cargo\n";
            if (DataAdmissao > DateTime.Now.AddMonths(2))
                resultadoValidação += "Data de admissão inválida\n";
            if (Senha.Length <= 3)
                resultadoValidação += "A senha não pode ser menor que três caracteres\n";
            if (base.ValidatePerson() != "VALIDO")
                resultadoValidação += base.ValidatePerson();
            if (resultadoValidação == "")
                resultadoValidação += "VALIDO";
            return resultadoValidação;
        }

        public override string ToString()
        {
            return $" {id} {Name} {MatriculaInterna} {Phone} {UsuarioAcesso} {Cargo}";
        }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   id == funcionario.id &&
                   Name == funcionario.Name &&
                   UniqueId == funcionario.UniqueId &&
                   Address == funcionario.Address &&
                   Phone == funcionario.Phone &&
                   Email == funcionario.Email &&
                   IsPhysicalPerson == funcionario.IsPhysicalPerson &&
                   MatriculaInterna == funcionario.MatriculaInterna &&
                   UsuarioAcesso == funcionario.UsuarioAcesso &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   Cargo == funcionario.Cargo &&
                   Salario == funcionario.Salario &&
                   Senha == funcionario.Senha;
        }

        public override int GetHashCode()
        {
            int hashCode = 497940720;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + IsPhysicalPerson.GetHashCode();
            hashCode = hashCode * -1521134295 + MatriculaInterna.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UsuarioAcesso);
            hashCode = hashCode * -1521134295 + DataAdmissao.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cargo);
            hashCode = hashCode * -1521134295 + Salario.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Senha);
            return hashCode;
        }
    }
}
