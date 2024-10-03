using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public class FuncionariosRepository : RepositoryBase
    {
        public static Funcionario? ConsultarPorId(int idFuncionario)
        {
            var resultado = Select($"SELECT * FROM Funcionarios WHERE IdFuncionario = {idFuncionario}");
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

        public static List<Funcionario> ConsultarPorNome(string nome)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            var resultado = Select($"SELECT * FROM Funcionarios WHERE Nome LIKE '%{nome}%'");
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

        public static List<Funcionario> ConsultarPorSetor(string setor)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            var resultado = Select($"SELECT * FROM Funcionarios WHERE Setor LIKE '%{setor}%'");
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

        public static int Cadastrar(Funcionario novoFuncionario)
        {
            var resultado = Update($@"
                INSERT INTO Funcionarios (IdFuncionario, Nome, Setor, Email, Senha) VALUES
                ({novoFuncionario.IdFuncionario}, {novoFuncionario.Nome}, '{novoFuncionario.Setor}',
                {novoFuncionario.Email}, {novoFuncionario.Senha})
                ");
            return resultado;
        }

        public static int Alterar(Funcionario funcionarioAlterar)
        {
            var resultado = Update($@"
                UPDATE Funcionarios SET
                Nome = {funcionarioAlterar.Nome},
                Setor = '{funcionarioAlterar.Setor}',
                Email = {funcionarioAlterar.Email},
                Senha = {funcionarioAlterar.Senha},
                WHERE IdFuncionario = {funcionarioAlterar.IdFuncionario}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idFuncionario)
        {
            return Update($"DELETE FROM Funcionarios WHERE IdFuncionario = {idFuncionario}");
        }
    }
}
