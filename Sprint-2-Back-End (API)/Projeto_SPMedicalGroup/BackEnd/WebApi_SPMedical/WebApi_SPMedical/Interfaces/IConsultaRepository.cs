using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;

namespace WebApi_SPMedical.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> Listar();

        Consultum BuscarPorId(int id);

        void Cadastrar(Consultum novoConsultum);

        void Atualizar(int id, Consultum ConsultumAtualizado);

        void Deletar(int id);

        List<Consultum> MinhasC(int idUsuario);

        void StatusAlterar(int id, string ConsultumPermissao);

        void Prontuario(int id, Consultum novoProntuario);
    }
}
