using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel.Models;
using Persistencia;


namespace Teste_prova.net_mvc4.Tests.persistencia
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaConexao()
        {
            ConexaoBd conexaoBd = new ConexaoBd();
            SqlConnection conexao = conexaoBd.GetConnection();
            Assert.IsNotNull(conexao);
        }

        [TestMethod]
        public void TestaGravacao()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Aluno aluno = new Aluno()
                {
                    Nome = "Ze",
                    Cpf = "2013",
                    DataNascimento = "10/10/1910",
                    Rg = "30211404",
                    Curso = 2
                };
            Assert.IsTrue(dao.Gravar(aluno));
        }

        [TestMethod]
        public void TestarDeletar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Assert.IsTrue(dao.Deletar("2015", "cpf"));
        }

        [TestMethod]
        public void TestarBuscar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Assert.IsNotNull(dao.Buscar("58495670", "cpf"));
            
        }

        [TestMethod]
        public void TestarListar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();            
            Assert.IsTrue(dao.Listar().Count > 0);
        }

        [TestMethod]
        public void TestarAlterar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Aluno aluno = new Aluno()
            {
                Nome = "ze",
                Cpf = "2015",
                DataNascimento = "10/10/1987",
                Rg = "30211404",
                Curso = 3
            };
            Assert.IsTrue(dao.Alterar(aluno, "2013", "cpf"));
        }

        [TestMethod]
        public void TestData()
        {
            var dt = new DateTime();
            String s = "10/10/1910";
            dt = Convert.ToDateTime(s);
            var dt2 = new DateTime();
            dt2 = Convert.ToDateTime("10/10/1910");
            Assert.AreEqual(dt.ToString(),dt2.ToString());
        }


    }
}
