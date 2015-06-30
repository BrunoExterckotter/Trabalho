using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Dominio;
using CriarPessoa.Infra;
using CriarPessoa.Infra.Data;

namespace CriarPessoa
{
    [TestClass]
    public class PessoaDomainTest
    {
        [TestMethod]
        public void CreateAPessoaTest()
        {
            Pessoa pessoa = ObjectMother.GetPessoa();

            Assert.IsNotNull(pessoa);
        }

        [TestMethod]
        public void CreateAValidPessoaTest()
        {
            Pessoa pessoa = ObjectMother.GetPessoa(); 

            Validator.Validate(pessoa);
        }


       

        

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidPessoaNameTest()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "";

            Validator.Validate(pessoa);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidPessoaDataNascimentoTest()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Bruno";
            pessoa.DataNascimento = new DateTime(1990, 06, 01, 0, 0, 0);


            Validator.Validate(pessoa);
        }



    }
}
