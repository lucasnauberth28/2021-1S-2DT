using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Contexts;
using WebApi_SPMedical.Domains;
using WebApi_SPMedical.Interfaces;

namespace WebApi_SPMedical.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(x => x.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
