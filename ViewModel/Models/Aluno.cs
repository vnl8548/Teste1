using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Models
{
    public class Aluno
    {        
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string Cpf { get; set; }       
        public string Rg { get; set; }        
        public string DataNascimento { get; set; }
        public int Curso { get; set; }        
    }
}
