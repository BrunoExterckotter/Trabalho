using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Dominio
{
    public interface IPessoaRepository
    {
        Pessoa Save(Pessoa funcionario);
        Pessoa Get(int id);
        Pessoa Update(Pessoa funcionario);
        Pessoa Delete(int i);
        List<Pessoa> GetAll();

        List<Pessoa> GetById(int id);
    }
}
