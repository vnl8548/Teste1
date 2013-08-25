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
                Nome = "seu nome",
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

        public ActionResult Busca()
        {
            return View();
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
