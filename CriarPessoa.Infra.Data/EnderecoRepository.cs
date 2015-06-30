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
    public class EnderecoRepository : IEnderecoRepository
    {
         private PessoaContext context;

        public EnderecoRepository()
        {
            context = new PessoaContext();
        }

        public Endereco Save(Endereco post)
        {
            var newEndereco = context.Enderecos.Add(post);
            context.SaveChanges();
            return newEndereco;
        }


        public Endereco Get(int id)
        {
            var endereco = context.Enderecos.Find(id);
            return endereco;
        }


        public Endereco Update(Endereco endereco)
        {
            DbEntityEntry entry = context.Entry(endereco);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return endereco;
        }


        public Endereco Delete(int id)
        {
            var endereco = context.Enderecos.Find(id);
            DbEntityEntry entry = context.Entry(endereco);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return endereco;
        }

        public List<Endereco> GetAll()
        {
            return context.Enderecos.ToList();
        }
    }
}
