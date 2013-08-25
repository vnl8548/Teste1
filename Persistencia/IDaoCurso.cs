using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Models;


namespace Persistencia
{
    public interface IDaoCurso
    {
        bool Gravar(object curso);
        Curso Buscar(String palavra, String filtro);
        List<Curso> Listar();
        bool Deletar(String palavra, String filtro);
        bool Alterrar(Curso aluno, String id);
    }
}
