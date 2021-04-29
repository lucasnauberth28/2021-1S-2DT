using Peoples.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, TipoUsuarioDomain tipoUsuario);

        void Deletar(int id);
    }
}
