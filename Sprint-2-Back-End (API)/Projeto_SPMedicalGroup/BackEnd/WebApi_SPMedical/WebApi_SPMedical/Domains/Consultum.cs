using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Consultas
    /// </summary>
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "A Data da consulta é obrigatória!")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage ="A Descrição é obrigatória!")]
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
