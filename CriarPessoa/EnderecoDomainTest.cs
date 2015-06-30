using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Dominio;
using CriarPessoa.Infra;
using CriarPessoa.Infra.Data;

namespace CriarPessoa
{
    [TestClass]
    public class EnderecoDomainTest
    {
        [TestMethod]
        public void CreateAEnderecoTest()
        {
            Endereco endereco = ObjectMother.GetEndereco();

            Assert.IsNotNull(endereco);
        }

        [TestMethod]
        public void CreateAValidEnderecoTest()
        {

            Endereco endereco = ObjectMother.GetEndereco();

            Validator.Validate(endereco);
        }

        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidEnderecoRuaTest()
        {

            Endereco endereco = new Endereco();
            endereco.Rua = "";


            Validator.Validate(endereco);
        }

       
    }
}
