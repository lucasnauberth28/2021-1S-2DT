using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Pacientes
    /// </summary>
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "A Data de Nascimento do paciente é obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Nome do paciente é obrigatório!")]
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "O RG do paciente é obrigatório!")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "O CPF do paciente é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O número de telefone do paciente é obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço do paciente é obrigatória!")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
