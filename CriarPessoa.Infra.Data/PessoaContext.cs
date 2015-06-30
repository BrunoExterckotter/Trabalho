using CriarPessoa.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Infra.Data
{
    public class PessoaContext: DbContext
    {
        public PessoaContext() : base("CriarPessoaDB") { }
        //public FuncionarioContext() : base("EmpresaDB") { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("TBPessoa");
            modelBuilder.Entity<Pessoa>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Endereco>().ToTable("TBEndereco");
            modelBuilder.Entity<Endereco>()
                .Property(b => b.Rua)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Pessoa>()
                 .HasMany(a => a.Enderecos)
                 .WithOptional()
                 .WillCascadeOnDelete(true);

          
           
        }
    
    }
}
