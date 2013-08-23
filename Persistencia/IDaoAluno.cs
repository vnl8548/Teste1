using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;


namespace Persistencia
{
    public interface IDaoAluno
    {
        bool Gravar(Aluno aluno);
        Aluno Buscar(String palavra, String filtro);
        List<Aluno> Listar();
        bool Deletar(String palavra, String filtro);
        bool Alterar(Aluno aluno, String palavra, String filtro);
    }
}
