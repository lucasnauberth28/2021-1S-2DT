using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;
using WebApi_SPMedical.Interfaces;

namespace WebApi_SPMedical.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            
        }

        public TipoUsuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
