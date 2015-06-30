using CriarPessoa.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Dominio
{
    public class Pessoa :IObjectValidation
    {
        public int Id { set; get; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Cpf")]
        public String Cpf { get; set; }

        public String Profissao { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }


         public void Validate()
         {
             if (string.IsNullOrEmpty(Nome))
                 throw new Exception("Nome Inválido");
             if (string.IsNullOrEmpty(Profissao))
                 throw new Exception("Profissao Inválida");

         }
    }
}
