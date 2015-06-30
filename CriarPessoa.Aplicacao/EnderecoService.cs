using CriarPessoa.Dominio;
using CriarPessoa.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Aplicacao
{
    public class EnderecoService:IEnderecoService
    {

        private IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }


        public Endereco Create(Endereco endereco)
        {
            Validator.Validate(endereco);

            var savedEndereco= _enderecoRepository.Save(endereco);

            return savedEndereco;
        }

        public Endereco Retrieve(int id)
        {
            return _enderecoRepository.Get(id);
        }


        public Endereco Update(Endereco endereco)
        {
            Validator.Validate(endereco);

            var updatedEndereco = _enderecoRepository.Update(endereco);

            return updatedEndereco;
        }


        public Endereco Delete(int id)
        {
            return _enderecoRepository.Delete(id);
        }


        public List<Endereco> RetrieveAll()
        {
            return _enderecoRepository.GetAll();
        }

    
    }
}
