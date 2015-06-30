using CriarPessoa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Aplicacao
{
    public interface IPessoaService

    {
        Pessoa Create(Pessoa pessoa);
        Pessoa Retrieve(int id);
        Pessoa Update(Pessoa pessoa);
        Pessoa Delete(int id);
        List<Pessoa> RetrieveAll();
    }
}
