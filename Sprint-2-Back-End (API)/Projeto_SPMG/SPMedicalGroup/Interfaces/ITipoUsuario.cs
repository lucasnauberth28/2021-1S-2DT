using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface ITipoUsuario
    {
        List<TipoUsuario> Listar();
        TipoUsuario IdBusca(int id);
        void Cadastrar(TipoUsuario newTipoUsuario);
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
