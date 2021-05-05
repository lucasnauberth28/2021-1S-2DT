using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Tipos de Usuários
    /// </summary>
    public partial class TipoUsuario
    {
       
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O Título do tipo de usuário é obrigatório!")]
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
