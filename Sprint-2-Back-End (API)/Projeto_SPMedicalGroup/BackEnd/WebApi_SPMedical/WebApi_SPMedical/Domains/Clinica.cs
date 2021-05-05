using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi_SPMedical.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de Clínicas
    /// </summary>
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O NomeFantasia é obrigatório!")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "A RazaoSocial é obrigatório!")]
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
