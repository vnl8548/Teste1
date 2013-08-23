using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FactoryDao
    {
        public static IDaoAluno GetDaoAluno()
        {
            return new MssqlAluno();
        }

        public static IDaoCurso GetDaoCurso()
        {
            return new MssqlCurso();
        }
    }
}
