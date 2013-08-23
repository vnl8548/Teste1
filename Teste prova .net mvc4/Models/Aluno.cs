using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teste_prova.net_mvc4.Models
{
    public class Aluno
    {        
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public int Curso { get; set; }        
    }
}
