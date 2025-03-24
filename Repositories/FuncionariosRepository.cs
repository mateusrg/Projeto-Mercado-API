using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

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

        public static List<VMMovimentacaoEstoque> ListarMovimentacoesDoFuncionario(int idFuncionario)
        {
            List<VMMovimentacaoEstoque> movimentacoesEstoque = [];
            var resultado = Select($@"SELECT * FROM MovimentacoesEstoque ME
                LEFT JOIN Estoques E ON ME.IdEstoque = E.IdEstoque
                LEFT JOIN TiposEstoque TE ON E.IdTipoEstoque = TE.IdTipoEstoque
                LEFT JOIN TiposMovimentacaoEstoque TME
                ON ME.IdTipoMovimentacaoEstoque = TME.IdTipoMovimentacaoEstoque
                LEFT JOIN Funcionarios F ON ME.idFuncionarioAutenticador = F.IdFuncionario
                LEFT JOIN Funcionarios Fu ON ME.IdFuncionarioSolicitador = Fu.IdFuncionario
                LEFT JOIN Produtos P ON ME.IdProduto = P.IdProduto
                WHERE IdFuncionarioSolicitador = {idFuncionario}
                OR IdFuncionarioAutenticador = {idFuncionario}
                ORDER BY ME.IdMovimentacaoEstoque DESC");

            while (resultado.Read())
            {
                var movimentacaoEstoque = new VMMovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    DescricaoEstoque = resultado.GetString(10),
                    IdTipoEstoque = resultado.GetInt32(9),
                    DescricaoTipoEstoque = resultado.GetString(12),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(13),
                    DescricaoMovimentacaoEstoque = resultado.GetString(14),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    NomeFuncionarioSolicitador = resultado.GetString(21),
                    SetorFuncionarioSolicitador = resultado.GetString(22),
                    EmailFuncionarioSolicitador = resultado.GetString(23),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    NomeFuncionarioAutenticador = resultado.GetString(16),
                    SetorFuncionarioAutenticador = resultado.GetString(17),
                    EmailFuncionarioAutenticador = resultado.GetString(18),
                    IdProduto = resultado.GetInt32(5),
                    CodBarrasProduto = resultado.GetString(26),
                    DescricaoProduto = resultado.GetString(27),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7),
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

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
            var resultado = Select($"SELECT * FROM Funcionarios WHERE Email = '{email}'");
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

        public static List<Funcionario> ConsultarPorNomeEmailSetorId(string texto)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            var resultado = Select($@"SELECT * 
                                    FROM Funcionarios 
                                    WHERE 
                                    IdFuncionario LIKE '%{texto}%' OR
                                    Nome LIKE '%{texto}%' OR
                                    Setor LIKE '%{texto}%' OR
                                    Email LIKE '%{texto}%'");
            while (resultado.Read())
            {
                var funcionario = new Funcionario()
                {
                    IdFuncionario = resultado.GetInt32(0),
                    Nome = resultado.GetString(1),
                    Setor = resultado.GetString(2),
                    Email = resultado.GetString(3),
                };
                funcionarios.Add(funcionario);
            }
            resultado.Close();
            return funcionarios;
        }

        public static int Cadastrar(Funcionario novoFuncionario)
        {
            var resultado = Update($@"
                INSERT INTO Funcionarios (Nome, Setor, Email, Senha) VALUES
                ('{novoFuncionario.Nome}', '{novoFuncionario.Setor}',
                '{novoFuncionario.Email}', '{novoFuncionario.Senha}')
                ");
            return resultado;
        }

        public static int Alterar(Funcionario funcionarioAlterar)
        {
            var resultado = Update($@"
                UPDATE Funcionarios SET
                Nome = '{funcionarioAlterar.Nome}',
                Setor = '{funcionarioAlterar.Setor}',
                Email = '{funcionarioAlterar.Email}',
                Senha = '{funcionarioAlterar.Senha}'
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