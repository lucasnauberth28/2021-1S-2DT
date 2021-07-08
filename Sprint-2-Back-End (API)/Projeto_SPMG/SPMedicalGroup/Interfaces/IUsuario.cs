using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IUsuario
    {
        List<Usuario> Listar();
        Usuario IdBusca(int id);
        void Cadastrar(Usuario novoUsuario);
        void AtualizarPorId(int id, Usuario usuarioAtualizado);
        Usuario BuscarPorEmailSenha(string email, string senha);
        void Deletar(int id);

    }
}
