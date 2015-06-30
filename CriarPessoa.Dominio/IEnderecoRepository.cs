﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarPessoa.Dominio
{
    public interface IEnderecoRepository
    {
        Endereco Save(Endereco endereco);
        Endereco Get(int id);
        Endereco Update(Endereco endereco);
        Endereco Delete(int i);

        List<Endereco> GetAll();
    }
}
