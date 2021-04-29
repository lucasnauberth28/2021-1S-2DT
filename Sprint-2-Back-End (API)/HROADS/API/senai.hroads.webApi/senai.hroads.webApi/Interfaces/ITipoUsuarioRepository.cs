using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        public List<TipoUsuarioDomain> Listar();
        void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado);
        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);
        void Deletar(int id);
    }
}
