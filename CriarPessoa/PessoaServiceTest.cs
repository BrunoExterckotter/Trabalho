using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Dominio;
using CriarPessoa.Infra;
using Moq;
using CriarPessoa.Aplicacao;
using CriarPessoa.Infra.Data;

namespace CriarPessoa
{
    [TestClass]
    public class PessoaServiceTest
    {
        [TestMethod]
        public void CreatePessoaServiceValidationAndPersistenceTest()
        {
            //Arrange
            Pessoa pessoa = ObjectMother.GetPessoa();
            //Fake do repositório
            var repositoryFake = new Mock<IPessoaRepository>();
            repositoryFake.Setup(r => r.Save(pessoa)).Returns(pessoa);
            //Fake do dominio
            var pessoaFake = new Mock<Pessoa>();
            pessoaFake.As<IObjectValidation>().Setup(b => b.Validate());

            IPessoaService service = new PessoaService(repositoryFake.Object);

            //Action
            service.Create(pessoaFake.Object);

            //Assert
            pessoaFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(pessoaFake.Object));
        }

        [TestMethod]
        public void RetrievePessoaServiceTest()
        {
            //Arrange
            Pessoa pessoa = ObjectMother.GetPessoa();
            //Fake do repositório
            var repositoryFake = new Mock<IPessoaRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(pessoa);

            IPessoaService service = new PessoaService(repositoryFake.Object);

            //Action
            var pessoaFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(pessoaFake);
        }

        [TestMethod]
        public void UpdatePessoaServiceValidationAndPersistenceTest()
        {
            //Arrange
            Pessoa pessoa = ObjectMother.GetPessoa();
            //Fake do repositório
            var repositoryFake = new Mock<IPessoaRepository>();
            repositoryFake.Setup(r => r.Update(pessoa)).Returns(pessoa);
            //Fake do dominio
            var pessoaFake = new Mock<Pessoa>();
            pessoaFake.As<IObjectValidation>().Setup(b => b.Validate());

            IPessoaService service = new PessoaService(repositoryFake.Object);

            //Action
            service.Update(pessoaFake.Object);

            //Assert
            pessoaFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(pessoaFake.Object));
        }

        [TestMethod]
        public void DeletePessoaServiceTest()
        {
            //Arrange
            Pessoa pessoa = null;
            //Fake do repositório
            var repositoryFake = new Mock<IPessoaRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(pessoa);

            IPessoaService service = new PessoaService(repositoryFake.Object);

            //Action
            var pessoaFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(pessoaFake);
        }

    }
}
