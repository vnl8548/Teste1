using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;
using Persistencia;

namespace Servico.Servico
{
    public class ServicoAluno
    {
        public ServicoAluno() {
        
        }

        public bool salvarAluno(Aluno aluno) { 
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            if (dao.Gravar(aluno))
            {
                return true;
            }
            else { 
                return false; 
            }
        }
    }
}
