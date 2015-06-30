using CriarPessoa.Aplicacao;
using CriarPessoa.Dominio;
using CriarPessoa.Infra;
using CriarPessoa.Infra.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa
{
    [TestClass]
    public class EnderecoServiceTest
    {

        [TestMethod]
        public void CreateEnderecoServiceValidationAndPersistenceTest()
        {
            //Arrange
            Endereco endereco = ObjectMother.GetEndereco();
            //Fake do repositório
            var repositoryFake = new Mock<IEnderecoRepository>();
            repositoryFake.Setup(r => r.Save(endereco)).Returns(endereco);
            //Fake do dominio
            var enderecoFake = new Mock<Endereco>();
            enderecoFake.As<IObjectValidation>().Setup(b => b.Validate());

            IEnderecoService service = new EnderecoService(repositoryFake.Object);

            //Action
            service.Create(enderecoFake.Object);

            //Assert
            enderecoFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(enderecoFake.Object));
        }


        [TestMethod]
        public void RetrieveEnderecoServiceTest()
        {
            //Arrange
            Endereco endereco = ObjectMother.GetEndereco();
            //Fake do repositório
            var repositoryFake = new Mock<IEnderecoRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(endereco);

            IEnderecoService service = new EnderecoService(repositoryFake.Object);

            //Action
            var enderecoFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(enderecoFake);
        }

        [TestMethod]
        public void UpdateEnderecoServiceValidationAndPersistenceTest()
        {
            //Arrange
            Endereco endereco = ObjectMother.GetEndereco();
            //Fake do repositório
            var repositoryFake = new Mock<IEnderecoRepository>();
            repositoryFake.Setup(r => r.Update(endereco)).Returns(endereco);
            //Fake do dominio
            var enderecoFake = new Mock<Endereco>();
            enderecoFake.As<IObjectValidation>().Setup(b => b.Validate());

            IEnderecoService service = new EnderecoService(repositoryFake.Object);

            //Action
            service.Update(enderecoFake.Object);

            //Assert
            enderecoFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(enderecoFake.Object));
        }

        [TestMethod]
        public void DeleteEnderecoServiceTest()
        {
            //Arrange
            Endereco endereco = null;
            //Fake do repositório
            var repositoryFake = new Mock<IEnderecoRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(endereco);

            IEnderecoService service = new EnderecoService(repositoryFake.Object);

            //Action
            var enderecoFake = service.Delete(1);

            //Asserts
            repositoryFake.Verify(r => r.Delete(1));

            Assert.IsNull(enderecoFake);
        }



    }
}
