using CriarPessoa.Dominio;
using CriarPessoa.Infra.Data;
//using CriarPessoa.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Aplicacao
{
    public class PessoaService : IPessoaService
    {
         private IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            Validator.Validate(pessoa);

            var savedPessoa = _pessoaRepository.Save(pessoa);

            return savedPessoa;
        }




        public Pessoa Retrieve(int id)
        {
            return _pessoaRepository.Get(id);
        }


        public Pessoa Update(Pessoa pessoa)
        {
            Validator.Validate(pessoa);

            var updatedPessoa = _pessoaRepository.Update(pessoa);

            return updatedPessoa;
        }


        public Pessoa Delete(int id)
        {
            return _pessoaRepository.Delete(id);
        }


        public List<Pessoa> RetrieveAll()
        {
            return _pessoaRepository.GetAll();
        }
    }
}
