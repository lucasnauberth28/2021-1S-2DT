using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        public List<UsuarioDomain> Listar();
        void Atualizar(int id, UsuarioDomain UsuarioAtualizado);
        void Cadastrar(UsuarioDomain novoUsuario);
        void Deletar(int id);
        UsuarioDomain BuscarPorId(int id);
    }
}
