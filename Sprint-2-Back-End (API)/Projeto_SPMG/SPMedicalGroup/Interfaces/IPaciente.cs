using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IPaciente
    {
        List<Paciente> Listar();
        Paciente BuscaId(int id);
        Paciente Cadastrar(Paciente newPaciente);
        void Atualizar(int id, Paciente pacienteAtualizado);
        List<Paciente> ListarConsultas(int id);
        void Deletar(int id);
    }
}
