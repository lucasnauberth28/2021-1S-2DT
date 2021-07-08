using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IMedico
    {
        List<Medico> Listar();
        Medico BuscaId(int id);
        void Cadastrar(Medico newMedico);
        void Atualizar(int id, Medico MedicoAtualizado);
        List<Medico> ListarConsultas(int id);
        void Deletar(int id);
    }
}
