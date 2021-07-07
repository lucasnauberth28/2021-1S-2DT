using System;
using System.Collections.Generic;

#nullable disable

namespace SPMG_WebApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTiposUsuarios { get; set; }
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
