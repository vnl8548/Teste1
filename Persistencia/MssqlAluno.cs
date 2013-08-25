using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;



namespace Persistencia
{
    public class MssqlAluno : IDaoAluno
    {
        public bool Gravar(Aluno aluno)
        {
            SqlConnection conexao = new ConexaoBd().GetConnection();
            conexao.Open();
            SqlCommand command = new SqlCommand
                {
                    Connection = conexao,
                    CommandText =
                        ("INSERT into aluno(nome, cpf, rg, dataNascimento, idCurso ) VALUES (@nome, @cpf, @rg, @dataNascimento, @idCurso );")
                };            
            command.Parameters.AddWithValue("@nome", aluno.Nome);
            command.Parameters.AddWithValue("@cpf", aluno.Cpf);
            command.Parameters.AddWithValue("@rg", aluno.Rg);
            command.Parameters.AddWithValue("@dataNascimento", Convert.ToDateTime(aluno.DataNascimento)); 
            command.Parameters.AddWithValue("@idCurso ", 2);            
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(aluno.Nome);
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return false;
        }

        public Aluno Buscar(string palavra, string filtro)
        {
            Aluno aluno = new Aluno();
            SqlConnection conexao = new ConexaoBd().GetConnection();
            conexao.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexao;
            command.CommandText = ("SELECT * from aluno WHERE " + filtro+ "= " + palavra);

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                aluno.Id = (int)reader["id"];
                aluno.Nome = (string) reader["nome"];
                aluno.Cpf = (string) reader["cpf"];
                aluno.Rg = (string) reader["rg"];
                aluno.Curso = (int) reader["idCurso"];
                aluno.DataNascimento = (string)reader["dataNascimento"];
                return aluno;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return null;
        }

        public List<Aluno> Listar(string palavra, string filtro)
        {            
            List<Aluno> lista = new List<Aluno>();
            SqlConnection conexao = new ConexaoBd().GetConnection();
            conexao.Open();
            SqlCommand command = new SqlCommand { 
                Connection = conexao,
                CommandText = ("SELECT * from aluno WHERE " + filtro+ " LIKE @palavra")
            };
            //command.Parameters.AddWithValue("@filtro", filtro);
            command.Parameters.AddWithValue("@palavra", String.Format("%{0}%", palavra));

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Aluno aluno = new Aluno()
                        {
                            Id = (int) reader["id"],
                            Nome = (string) reader["nome"],
                            Cpf =  (string)reader["cpf"],
                            Rg =  (string)reader["rg"],
                            Curso = (int) reader["idCurso"],
                            DataNascimento =  reader["dataNascimento"].ToString()                            
                        };
                    lista.Add(aluno);
                }

                return lista;
            }
            catch (Exception exception)
            {                
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return null;
        }

        public bool Deletar(string palavra, string filtro)
        {
            SqlConnection conexao = new ConexaoBd().GetConnection();
            conexao.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexao;
            command.CommandText = ("DELETE from aluno WHERE " + filtro +" = "+ palavra);                        
            try
            {
                command.ExecuteNonQuery();  
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return false;
        }

        public bool Alterar(Aluno aluno, String palavra, String filtro)
        {
            SqlConnection conexao = new ConexaoBd().GetConnection();
            conexao.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conexao;
            command.CommandText =
                "UPDATE aluno SET nome = @nome , cpf = @cpf, rg = @rg, dataNascimento = @dataNascimento, idCurso = @idCurso WHERE " +
                filtro + "= " + palavra;
            command.Parameters.AddWithValue("@nome", aluno.Nome);
            command.Parameters.AddWithValue("@cpf", aluno.Cpf);
            command.Parameters.AddWithValue("@rg", aluno.Rg);
            command.Parameters.AddWithValue("@dataNascimento", aluno.DataNascimento);
            command.Parameters.AddWithValue("@idCurso", aluno.Curso);
            try
            {
                Console.WriteLine(aluno.DataNascimento);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return false;            
            
        }
    }
}
