using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Situações
    /// </summary>
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacao { get; set; }

        [Required(ErrorMessage = "A situação é obrigatória!")]
        public string Situacao1 { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
