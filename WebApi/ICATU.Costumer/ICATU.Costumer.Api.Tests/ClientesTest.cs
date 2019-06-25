using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICATU.Costumer.Service;
using ICATU.Costumer.Domain.Models;
using ICATU.Costumer.Service.AutoMapper;

namespace ICATU.Costumer.Api.Tests
{
    [TestClass]
    public class ClientesTest
    {
        public ClientesTest()
        {
            AutoMapperConfig.Initialize();
        }
        [TestMethod]
        public void ValidaInsert()
        {
            var service = new ClientesService();

            var cliente = new ClienteModel
            {
                Nome = "Fulano deTal",
                Idade = 35,
                Cpf = new CpfModel("12343254689"),
                Endereco = new EnderecoModel
                {
                    Logradouro = "Avenida Presidente Vargas, 500",
                    Bairro = "Centro",
                    Cidade = "Juiz de Fora",
                    Estado = "Minas Gerais"
                }
            };
            var result = service.Insert(cliente);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void ValidaUpdate()
        {
            var service = new ClientesService();

            var clienteId = 1;
            var novoNome = "Fulano de Tal da Silva";
            var novaIdade = 34;

            var cliente = service.Get(clienteId);

            cliente.Nome = novoNome;
            cliente.Idade = novaIdade;

            var result = service.Update(cliente);

            var clienteAtualizado = service.Get(clienteId);

            Assert.IsTrue(result > 0);
            Assert.AreEqual(novoNome, clienteAtualizado.Nome);
            Assert.AreEqual(novaIdade, clienteAtualizado.Idade);
        }

        [TestMethod]
        public void ValidaDelete()
        {
            var service = new ClientesService();

            var clienteId = 1;

            var result = service.Delete(clienteId);

            var cliente = service.Get(clienteId);

            Assert.IsTrue(result > 0);
            Assert.IsNull(cliente);
        }
    }
}
