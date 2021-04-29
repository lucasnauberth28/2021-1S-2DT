using Peoples.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Interfaces
{
    interface IFuncionarioRepository
    { 

            List<FuncionarioDomain> Listar();

            FuncionarioDomain BuscarPorId(int id);

            FuncionarioDomain BuscarPorNome(string nome);

            void Deletar(int id);

            void Atualizar(int id, FuncionarioDomain funcionario);

            void Cadastrar(FuncionarioDomain novoFuncionario);
        }
    }

