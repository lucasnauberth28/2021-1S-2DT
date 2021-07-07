using SPMG_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> Listar();
        TiposUsuario BuscarPorId(int id);
        void Cadastrar(TiposUsuario novoTipoUsuario);
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
