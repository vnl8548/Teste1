using System;
using System.Web;
namespace Modelo
{
    public class Aluno
    {        
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public String DataNascimento { get; set; }
        public int Curso { get; set; }        
    }
}
