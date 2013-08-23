using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia
{
    public class ConexaoBd
    {
        public SqlConnection conexao { get; set; }          
        public SqlConnection GetConnection()
        {
            try
            {
                conexao = new SqlConnection("Data Source=VINICIUS-PC;Initial Catalog=provas;Integrated Security=True");
                return conexao;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;                
            }            
        }
    }
}
