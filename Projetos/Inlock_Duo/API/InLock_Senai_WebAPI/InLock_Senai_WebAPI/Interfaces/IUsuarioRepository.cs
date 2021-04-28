using InLock_Senai_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Usuario
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os generos 
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<UsuarioDomain> Listar();
        UsuarioDomain BuscarPorId(int id);
        void Atualizar(int id, UsuarioDomain usuarioAtualizado);
        void Cadastrar(UsuarioDomain novoUsuario);
        void Deletar(int id);
        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}
