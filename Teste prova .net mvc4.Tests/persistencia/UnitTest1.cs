using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
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
                    Nome = "joao",
                    Cpf = "58495670",
                    DataNascimento = "2010/10/10",
                    Rg = "30211404",
                    Curso = 2
                };
            Assert.IsTrue(dao.Gravar(aluno));
        }

        [TestMethod]
        public void TestarDeletar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Assert.IsTrue(dao.Deletar("nome", "joao"));
        }

        [TestMethod]
        public void TestarBuscar()
        {
            IDaoAluno dao = FactoryDao.GetDaoAluno();
            Assert.IsNotNull(dao.Buscar("58495670", "cpf"));
            Console.WriteLine(dao.Buscar("58495670", "cpf").DataNascimento);
            Assert.AreEqual("58495670", dao.Buscar("58495670", "cpf").Cpf);
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
                Nome = "joao",
                Cpf = "58495670",
                DataNascimento = "",
                Rg = "30211404",
                Curso = 3
            };
            Assert.IsTrue(dao.Alterar(aluno, aluno.Cpf, "cpf"));
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
