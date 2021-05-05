using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de especialidades (médicas)
    /// </summary>
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        [Required(ErrorMessage ="O Nome da especialidade é obrigatório!")]
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
