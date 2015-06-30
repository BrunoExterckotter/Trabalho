using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriarPessoa.Dominio;
using System.Collections.Generic;

namespace CriarPessoa
{

    public class ObjectMother
    {
        public static Pessoa GetPessoa()
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Bruno";

            pessoa.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            pessoa.Cpf = "09110956788";
            pessoa.Profissao = "Tester";
            pessoa.Enderecos = new List<Endereco>()
            {
                new Endereco()
                {
                    Rua = "João antunes pessoa",
                    Numero = 12,
                    Cep = "88525-580",
                    Cidade = "Lages",
                    Bairro = "Penha",
                   
                }
            };

            return pessoa;
        }


        public static Endereco GetEndereco()
        {

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Bruno2";            
            pessoa.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            pessoa.Cpf = "0911095678";
            pessoa.Profissao = "Tester";

            Endereco endereco = new Endereco();
            endereco.Rua = "João";
            endereco.Numero = 98;
            endereco.Cep = "0911095679";
            endereco.Cidade = "Lages";
            endereco.Bairro = "Penha";
            endereco.Pessoa = pessoa;

            return endereco;
        }

        public static List<Endereco> GetEnderecos()
        {
            List<Endereco> enderecos = new List<Endereco>();

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Bruno3";

            pessoa.DataNascimento = new DateTime(1995, 06, 01, 0, 0, 0);
            pessoa.Cpf = "0911095678";
            pessoa.Profissao = "Tester";

            Endereco endereco1 = new Endereco();
            endereco1.Rua = "João";
            endereco1.Numero = 98;
            endereco1.Cep = "0911095679";
            endereco1.Cidade = "Lages";
            endereco1.Pessoa = pessoa;

            Endereco endereco2 = new Endereco();
            endereco2.Rua = "João";
            endereco2.Numero = 98;
            endereco2.Cep = "0911095679";
            endereco2.Cidade = "Lages";
            endereco2.Pessoa = pessoa;
           

           
            enderecos.Add(endereco1);
            enderecos.Add(endereco2);
           

            return enderecos;
        }

       }
}
