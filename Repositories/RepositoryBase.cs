using System.Data.SqlClient;

namespace Projeto_Mercado_API.Repositories

{
    public class RepositoryBase
    {
        private static string ConnString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=projetomercado;Persist Security Info=True;User ID=maisprati;Password=maisprati;Integrated Security=false";
        public static SqlConnection Connection = new SqlConnection(ConnString);

        private static bool VerifyConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    Connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static SqlDataReader Select(string sql)
        {
            if (!VerifyConnection())
            {
                throw new Exception("Erro ao verificar a conexão com o banco.");
            }

            var command = new SqlCommand(sql, Connection);
            var resultado = command.ExecuteReader();
            return resultado;
        }
        public static int Update(string sql)
        {
            if (!VerifyConnection())
            {
                throw new Exception("Erro ao verificar a conexão com o banco.");
            }

            var command = new SqlCommand(sql, Connection);
            var resultado = command.ExecuteNonQuery();
            return resultado;
        }
    }
}
