using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(MedicosMetadado))]
    public partial class Medicos
    {

    }

    public class MedicosMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caractéres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O E-mail deve possuir no máximo 80 caractéres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Endereço")]
        [StringLength(100, ErrorMessage = "O Endereço deve possuir no máximo 100 caractéres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Bairro")]
        [StringLength(60, ErrorMessage = "O E-mail deve possuir no máximo 60 caractéres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caractéres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se Atende por Convênio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se Tem Clínica")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O Website deve possuir no máximo 80 caractéres")]
        public string WebsiteBlog { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Cidade")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Especialidade")]
        public int IDEspecialidade { get; set; }
    }
}