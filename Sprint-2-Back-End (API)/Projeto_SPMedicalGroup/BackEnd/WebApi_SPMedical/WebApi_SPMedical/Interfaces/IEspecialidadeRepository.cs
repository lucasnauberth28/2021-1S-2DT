using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;

namespace WebApi_SPMedical.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        Especialidade BuscarPorId(int id);

        Especialidade BuscarPorEspecialidade(string especialidade);

         void Cadastrar(Especialidade novoEspecialidade);

        bool Atualizar(int id, Especialidade especialidadeAtualizado);

        void Deletar(int id);
    }
}
