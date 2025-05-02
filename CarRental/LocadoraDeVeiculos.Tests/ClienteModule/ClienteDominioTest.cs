using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarRental.Domain.ClienteModule;

namespace CarRental.Tests.ClienteModule
{
    [TestClass]
    public class ClienteDominioTest
    {
        Customer cliente;

        [TestMethod]
        public void DeveCriarClienteCorreto_CompletoPessoaFisica()
        {
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("VALIDO", resultadoValidaca);
        }

        [TestMethod]
        public void DeveCriarClienteCorreto_CompletoPessoaJuridica()
        {
            cliente = new Customer(0, "Name Teste", "29.073.791/0001-61", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), false);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("VALIDO", resultadoValidaca);
        }

        [TestMethod]
        public void DeveCriarClienteCorreto_SemTelefone()
        {
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("VALIDO", resultadoValidaca);
        }

        [TestMethod]
        public void DeveApresentarErro_SemEmailETelefone()
        {
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "", "", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("O e-mail é obrigatório está incorreto e deve estar correto\n", resultadoValidaca);
        }

        [TestMethod]
        public void DeveApresentarErro_PessoaFisica()
        {
            cliente = new Customer(0, "", "", "", "", "", "", new DateTime(2000, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("CNH inválida\nCNH fora do prazo de validade\nO nome não pode ser nulo\nO endereço não pode ser nulo\nO e-mail é obrigatório está incorreto e deve estar correto\nO CPF não é válido\n", resultadoValidaca);
        }

        [TestMethod]
        public void DeveApresentarErro_PessoaFisicaSemCnh()
        {
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "", new DateTime(2030, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("CNH inválida\n", resultadoValidaca);
        }

        [TestMethod]
        public void DeveApresentarErro_PessoaFisicaCnhComDataInvalida()
        {
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2000, 01, 01), true);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("CNH fora do prazo de validade\n", resultadoValidaca);
        }

        [TestMethod]
        public void DeveApresentarErro_PessoaJuridica()
        {
            cliente = new Customer(0, "", "", "", "", "", "", null, false);

            string resultadoValidaca = cliente.Validate();

            Assert.AreEqual("O nome não pode ser nulo\nO endereço não pode ser nulo\nO e-mail é obrigatório está incorreto e deve estar correto\nO CNPJ não é válido\n", resultadoValidaca);
        }

        #region Testes para as propriedades herdadas de Pessoa
        [TestMethod]
        public void DeveCriarPessoa_Completo()
        {
            cliente = new Customer(1, "nome", "11111111111", "endereco", "999999999", "email@g.com", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("VALIDO", resultado);
        }

        [TestMethod]
        public void DeveCriarPessoa_SemTelefone()
        {
            cliente = new Customer(1, "nome", "11111111111", "endereco", "", "email@g.com", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("VALIDO", resultado);
        }

        [TestMethod]
        public void DeveApresentarErroPessoa_PessoaTotalmenteInvalida()
        {
            cliente = new Customer(1, "", "", "", "", "", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("O nome não pode ser nulo\nO endereço não pode ser nulo\nO e-mail é obrigatório está incorreto e deve estar correto\nO CPF não é válido\n", resultado);
        }

        [TestMethod]
        public void DeveApresentarErroPessoa_PessoaInvalidaComEmailSemArrobaEUmNumeroNoTelefone()
        {
            cliente = new Customer(1, "", "", "", "1", "a", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("O nome não pode ser nulo\nO endereço não pode ser nulo\nO e-mail é obrigatório está incorreto e deve estar correto\nO CPF não é válido\n", resultado);
        }

        [TestMethod]
        public void DeveApresentarErroPessoa_PessoaValidaComEmailSemArrobaTelefoneApenasUmNumero()
        {
            cliente = new Customer(1, "nome", "11111111111", "endereco", "9", "email", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("O e-mail é obrigatório está incorreto e deve estar correto\n", resultado);
        }

        [TestMethod]
        public void DeveApresentarErroPessoa_PessoaValidaApenasUmNumeroDeCelularApenas()
        {
            cliente = new Customer(1, "nome", "11111111111", "endereco", "9", "email@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            string resultado = cliente.Validate();

            Assert.AreEqual("VALIDO", resultado);
        }
        #endregion
    }
}
