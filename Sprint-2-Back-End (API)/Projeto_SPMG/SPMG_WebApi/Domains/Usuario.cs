using System;
using System.Collections.Generic;

#nullable disable

namespace SPMG_WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTiposUsuarios { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public virtual TiposUsuario IdTiposUsuariosNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
