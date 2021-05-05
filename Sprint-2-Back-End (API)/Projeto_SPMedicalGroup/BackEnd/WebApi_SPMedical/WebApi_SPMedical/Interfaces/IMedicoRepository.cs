using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;

namespace WebApi_SPMedical.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();

        Medico BuscarPorId(int id);

        void Cadastrar(Medico    novoEspecialidade);

        bool Atualizar(int id, Medico medicoAtualizado);

        void Deletar(int id);
    }
}
