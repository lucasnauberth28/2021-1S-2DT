using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Usuários
    /// </summary>
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O Email do paciente é obrigatória!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha do paciente é obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
