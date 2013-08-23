using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;


namespace Persistencia
{
    public class MssqlCurso : IDaoCurso
    {
        public bool Gravar(object curso)
        {
            throw new NotImplementedException();
        }

        public Curso Buscar(string palavra, string filtro)
        {
            throw new NotImplementedException();
        }

        public List<Curso> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Deletar(string palavra, string filtro)
        {
            throw new NotImplementedException();
        }

        public bool Alterrar(Curso aluno, string id)
        {
            throw new NotImplementedException();
        }
    }
}
