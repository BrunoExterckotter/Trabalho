using CriarPessoa.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Dominio
{
    public class Endereco : IObjectValidation
    {
        public int Id { set; get; }
        public string Rua { get; set; }

        public double Numero { get; set; }
        public String Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
        [DisplayName("Pessoa")]
        public virtual Pessoa Pessoa { set; get; }


        public void Validate()
        {
            if (string.IsNullOrEmpty(Rua))
                throw new Exception("Nome da rua Inválido");

        }
    }
    }

