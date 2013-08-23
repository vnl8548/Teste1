using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Persistencia;


namespace Teste_prova.net_mvc4.Controllers
{
    public class AlunoController : Controller
    {


        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Aluno aluno1 = new Aluno()
            {
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                DataNascimento = aluno.DataNascimento,
                Rg = aluno.Rg,
                Curso = 2
            };                      
            dao.Gravar(aluno1);            
            return View(aluno);
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

        public ActionResult ListarPromocao(double longitude, double latitude)
        {
            return Json(new
            {
                IdEmpresa = 1,
                NomeEmpresa = "Empresa00",
                UrlEmpresa = "www.urlEmpresa/empresa.jpg",
                UrlPromocao = "www.urlPropaganda/empresa.jpg",
                Promocao = "Façalalalal"
            });
        }

    }
}
