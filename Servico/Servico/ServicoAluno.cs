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

        public List<Aluno> buscarAluno(string palavra, string filtro) {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            try { 
                List<Aluno> lista =
                dao.Listar(palavra, filtro);
                if (lista != null)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
