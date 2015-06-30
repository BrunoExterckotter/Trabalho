using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Infra.Data;
using System.Data.Entity;
using CriarPessoa.Dominio;

namespace CriarPessoa
{
    [TestClass]
    public class PessoaRepositoryTest
    {
        private PessoaContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<PessoaContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new PessoaContext();

            var pessoa = ObjectMother.GetPessoa();

            var pessoaJoao = ObjectMother.GetPessoa();
            pessoaJoao.Nome = "Joao Paulo";


            var pessoaMaria = ObjectMother.GetPessoa();
            pessoaMaria.Nome = "Maria";


            _contextForTest.Pessoas.Add(pessoaJoao);

            _contextForTest.Pessoas.Add(pessoaMaria);

            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void RetrievePessoaRepositoryTest()
        {
            //Arrange
            IPessoaRepository repository = new PessoaRepository();

            //Action
            Pessoa pessoa = repository.Get(1);

            //Assert
            Assert.IsNotNull(pessoa);
            Assert.IsTrue(pessoa.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(pessoa.Nome));
             Assert.IsFalse(string.IsNullOrEmpty(pessoa.Profissao));

        }

        [TestMethod]
        public void UpdatePessoaRepositoryTest()
        {
            //Arrange
            IPessoaRepository repository = new PessoaRepository();
            Pessoa pessoa = _contextForTest.Pessoas.Find(2);
            pessoa.Nome = "Teste";
            pessoa.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            pessoa.Cpf = "902901920192";
            pessoa.Profissao = "Programador";

            //Action
            var updatedPessoa = repository.Update(pessoa);

            //Assert
            //   IFuncionarioRepository repository2 = new FuncionarioRepository();
            var persistedPessoa = _contextForTest.Pessoas.Find(2);
            Assert.IsNotNull(updatedPessoa);
            Assert.AreEqual(updatedPessoa.Id, persistedPessoa.Id);
            Assert.AreEqual(updatedPessoa.Nome, persistedPessoa.Nome);
            Assert.AreEqual(updatedPessoa.DataNascimento, persistedPessoa.DataNascimento);
            Assert.AreEqual(updatedPessoa.Cpf, persistedPessoa.Cpf);
            Assert.AreEqual(updatedPessoa.Profissao, persistedPessoa.Profissao);

            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            // updatedBlog.Should().NotBeNull();
            //updatedBlog.ShouldBeEquivalentTo(persistedBlog);
        }

        [TestMethod]
        public void DeletePessoaRepositoryTest()
        {
            //Arrange
            IPessoaRepository repository = new PessoaRepository();

            //Action
            var deletedPessoa = repository.Delete(1);

            //Assert
            var contextForTest = new PessoaContext();
            var persistedPessoa = contextForTest.Pessoas.Find(1);
            Assert.IsNull(persistedPessoa);


            //Assert - utilizando o Framework FluentAssertions
            //Apenas um exemplo didático (NÃO CAI NA PROVA)
            //  persistedFuncionario.Should().BeNull();
        }



        [TestMethod]
        public void RetrieveAllPessoasRepositoryTest()
        {
            IPessoaRepository repository = new PessoaRepository();

            //Action
            var pessoas = repository.GetAll();

            //Assert
            Assert.IsNotNull(pessoas);
            Assert.IsTrue(pessoas.Count >= 5);
        }




    }
}
