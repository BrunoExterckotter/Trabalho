using CriarPessoa.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Infra.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private PessoaContext context;

        public PessoaRepository()
        {
            context = new PessoaContext();
        }

        public Pessoa Save(Pessoa pessoa)
        {
            var newPessoa= context.Pessoas.Add(pessoa);
            context.SaveChanges();
            return newPessoa;
        }


        public Pessoa Get(int id)
        {
            var pessoa = context.Pessoas.Find(id);
            return pessoa;
        }


        public Pessoa Update(Pessoa pessoa)
        {
            DbEntityEntry entry = context.Entry(pessoa);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return pessoa; 
        }


        public Pessoa Delete(int id)
        {
            var pessoa = context.Pessoas.Find(id);
            DbEntityEntry entry = context.Entry(pessoa);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return pessoa;
        }


        public List<Pessoa> GetAll()
        {
            return context.Pessoas.ToList();
        }


        public List<Pessoa> GetById(int id)
        {
            return context.Pessoas.Where(pessoa => pessoa.Id == id).ToList();
        }
    }
}
