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
        void Cadastrar(Consultum novoConsulta);

        bool Atualizar(int id, Consultum consultaAtualizada);

        void Deletar(int id);
    }
}
