using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Infra.Data;
using System.Data.Entity;
using CriarPessoa.Dominio;

namespace CriarPessoa
{
    [TestClass]
    public class EnderecoRepositoryTest
    {
        private PessoaContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<PessoaContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new PessoaContext();
            _contextForTest.Enderecos.AddRange(ObjectMother.GetEnderecos());
            _contextForTest.SaveChanges();
        }


        [TestMethod]
        public void CreateEnderecoRepositoryTest()
        {
            //Arrange
            Endereco p = ObjectMother.GetEndereco();
            IEnderecoRepository repository = new EnderecoRepository();

            //Action
            Endereco newEndereco= repository.Save(p);

            //Assert
            Assert.IsTrue(newEndereco.Id > 0);
        }

        [TestMethod]
        public void RetrieveEnderecoRepositoryTest()
        {
            //Arrange
            IEnderecoRepository repository = new EnderecoRepository();

            //Action
            Endereco endereco = repository.Get(1);

            //Assert
            Assert.IsNotNull(endereco);
            Assert.IsTrue(endereco.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(endereco.Rua));

        }
        [TestMethod]
        public void UpdateEnderecoRepositoryTest()
        {
            //Arrange
            IEnderecoRepository repository = new EnderecoRepository();
            Pessoa pessoa = _contextForTest.Pessoas.Find(1);
            pessoa.Nome = "Teste";
            pessoa.DataNascimento = new DateTime(1970, 06, 01, 0, 0, 0);
            pessoa.Cpf = "902901920192";
            pessoa.Profissao = "Programador";

            Endereco endereco = _contextForTest.Enderecos.Find(1);
            endereco.Rua = "blabla";
            endereco.Bairro = "penha";
            endereco.Cep = "988989";
            endereco.Cidade = "Lages";
            endereco.Numero = 5;  
            endereco.Pessoa = pessoa;

            //Action
            var updatedEndereco = repository.Update(endereco);

            //Assert
            var persistedEndereco = _contextForTest.Enderecos.Find(1);
            Assert.IsNotNull(updatedEndereco);
            Assert.AreEqual(updatedEndereco.Id, persistedEndereco.Id);
            Assert.AreEqual(updatedEndereco.Rua, persistedEndereco.Rua);
            Assert.AreEqual(updatedEndereco.Numero, persistedEndereco.Numero);
            Assert.AreEqual(updatedEndereco.Cep, persistedEndereco.Cep);
            Assert.AreEqual(updatedEndereco.Bairro, persistedEndereco.Bairro);
            Assert.AreEqual(updatedEndereco.Cidade, persistedEndereco.Cidade);
            Assert.AreEqual(updatedEndereco.Pessoa, persistedEndereco.Pessoa);


        }

        [TestMethod]
        public void DeleteEnderecoRepositoryTest()
        {
            //Arrange
            IEnderecoRepository repository = new EnderecoRepository();

            //Action
            var deletedEndereco = repository.Delete(1);

            //Assert
           
            var persistedEndereco = _contextForTest.Enderecos.Find(1);
            Assert.IsNull(persistedEndereco);

        }



    }
}
