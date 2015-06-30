using CriarPessoa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Aplicacao
{
    public interface IEnderecoService
    {
        Endereco Create(Endereco endereco);
        Endereco Retrieve(int id);
        Endereco Update(Endereco endereco);
        Endereco Delete(int id);
        List<Endereco> RetrieveAll();
    }
}
