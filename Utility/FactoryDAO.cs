using Persistencia;

namespace Utility
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
