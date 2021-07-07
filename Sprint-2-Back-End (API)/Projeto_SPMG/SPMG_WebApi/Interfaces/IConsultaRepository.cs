using SPMG_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Interfaces
{
    interface IConsultaRepository { 
       List<Consulta> Listar();

        Consulta BuscarPorId(int id);

       void Cadastrar(Consulta novaConsulta);

       void Atualizar(int id, Consulta ConsultaAtualizada);

       void Deletar(int id);

      List<Consulta> Minhas(int idUsuario);

       void AlterStatus(int id, string ConsultaPermissao);

       void Prontuario(int id, Consulta novoProntuario);
    }
}
