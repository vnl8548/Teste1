using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Models;
using System.Web.Script.Serialization;
using Servico.Servico;

namespace Teste_prova.net_mvc4.Controllers
{
    public class AlunoController : Controller
    {


        public ActionResult Cadastro()
        {
            Aluno aluno = new Aluno
            {
                Nome = "",
                Cpf = "",
                Rg = "",
                DataNascimento = System.DateTime.Now.ToString(),
                Curso = 1
            };
            return View(aluno);
        }

        
        public JsonResult Salvar(string dadosAluno, string dtNasc)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Aluno novoAluno = jsSerializer.Deserialize<Aluno>(dadosAluno);
            novoAluno.DataNascimento = dtNasc;            
            ServicoAluno servico = new ServicoAluno();            
            servico.salvarAluno(novoAluno);
            return Json(true);
        }

        public ActionResult Busca() {
            return View();
        }

        public JsonResult FazBusca(string palavraChave, string filtro)
        {
            ServicoAluno servico = new ServicoAluno();
            List<Aluno> aluno = servico.buscarAluno(palavraChave,filtro);
            
            if (aluno!= null)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                var novoJson = jsSerializer.Serialize( new  { 
                     Alunos = aluno                     
                }).ToString();
                return Json(novoJson);
                /*return Json(new
                {
                    aluno = new []
                    {
                        new 
                        {
                            Nome = aluno.ElementAt(1).Nome,
                            Cpf = aluno.ElementAt(1).Cpf,
                            Rg = aluno.ElementAt(1).Rg,
                            DtNasc = aluno.ElementAt(1).DataNascimento,
                            Curso = aluno.ElementAt(1).Curso
                        }
                    }
                });*/
            }
            else {
                return Json(null);
            }
            
        }

        public ActionResult Alterar()
        {
            return View();
        }

        public ActionResult Deletar()
        {

            return View();
        }        

    }
}
