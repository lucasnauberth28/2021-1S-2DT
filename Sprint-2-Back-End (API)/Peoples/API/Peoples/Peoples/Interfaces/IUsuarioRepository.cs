using Peoples.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain Logar(string email, string senha);

        UsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, UsuarioDomain usuario);

        void Deletar(int id);

        void Cadastrar(UsuarioDomain novoUsuario);
    }
}
