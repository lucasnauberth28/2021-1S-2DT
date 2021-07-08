using SPMedicalGroup.Contexts;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscada = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscada.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.Update(tipoUsuarioBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario newTipoUsuario)
        {
            ctx.TipoUsuarios.Add(newTipoUsuario);
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == id);

            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario IdBusca(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
