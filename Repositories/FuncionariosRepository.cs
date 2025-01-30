using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public class FuncionariosRepository : RepositoryBase
    {
        public static List<Funcionario> ListarTodos()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            var resultado = Select($"SELECT * FROM Funcionarios");
            while (resultado.Read())
            {
                var funcionario = new Funcionario()
                {
                    IdFuncionario = resultado.GetInt32(0),
                    Nome = resultado.GetString(1),
                    Setor = resultado.GetString(2),
                    Email = resultado.GetString(3),
                    Senha = resultado.GetString(4)
                };
                funcionarios.Add(funcionario);
            }
            resultado.Close();
            return funcionarios;
        }


        public static Funcionario? ConsultarPorEmail(string email)
        {
            var resultado = Select($"SELECT * FROM Funcionarios WHERE Email = {email}");
            if (resultado.Read())
            {
                var funcionario = new Funcionario()
                {
                    IdFuncionario = resultado.GetInt32(0),
                    Nome = resultado.GetString(1),
                    Setor = resultado.GetString(2),
                    Email = resultado.GetString(3),
                    Senha = resultado.GetString(4)
                };
                resultado.Close();
                return funcionario;
            }
            resultado.Close();
            return null;
        }
    }
}