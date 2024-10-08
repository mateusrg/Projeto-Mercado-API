using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public class MovimentacoesEstoqueRepository : RepositoryBase
    {
        public static List<MovimentacaoEstoque> ListarTodos()
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static MovimentacaoEstoque? ConsultarPorId(int idMovimentacaoEstoque)
        {
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdMovimentacaoEstoque = {idMovimentacaoEstoque}");
            if (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                resultado.Close();
                return movimentacaoEstoque;
            }
            resultado.Close();
            return null;
        }

        public static List<MovimentacaoEstoque> ConsultarPorEstoque(int idEstoque)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdEstoque = {idEstoque}");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static List<MovimentacaoEstoque> ConsultarPorTipoMovimentacaoEstoque(int idTipoMovimentacaoEstoque)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdTipoMovimentacaoEstoque = {idTipoMovimentacaoEstoque}");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static List<MovimentacaoEstoque> ConsultarPorFuncionarioSolicitador(int idFuncionarioSolicitador)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdFuncionarioSoliticador = {idFuncionarioSolicitador}");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static List<MovimentacaoEstoque> ConsultarPorFuncionarioAutenticador(int idFuncionarioAutenticador)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdFuncionarioAutenticador = {idFuncionarioAutenticador}");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static List<MovimentacaoEstoque> ConsultarPorProduto(int idProduto)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM MovimentacoesEstoque WHERE IdProduto = {idProduto}");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static List<MovimentacaoEstoque> ConsultarPorData(string dataInicio, string dataFim)
        {
            List<MovimentacaoEstoque> movimentacoesEstoque = new List<MovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM Compras WHERE Data >= '{dataInicio}' AND Data <= '{dataFim}'");
            while (resultado.Read())
            {
                var movimentacaoEstoque = new MovimentacaoEstoque()
                {
                    IdMovimentacaoEstoque = resultado.GetInt32(0),
                    IdEstoque = resultado.GetInt32(1),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(2),
                    IdFuncionarioSolicitador = resultado.GetInt32(3),
                    IdFuncionarioAutenticador = resultado.GetInt32(4),
                    IdProduto = resultado.GetInt32(5),
                    Quantidade = resultado.GetInt32(6),
                    DataHora = resultado.GetDateTime(7)
                };
                movimentacoesEstoque.Add(movimentacaoEstoque);
            }
            resultado.Close();
            return movimentacoesEstoque;
        }

        public static int Cadastrar(MovimentacaoEstoque novaMovimentacaoEstoque)
        {
            var resultado = Update($@"
                INSERT INTO MovimentacoesEstoque (IdEstoque, IdTipoMovimentacaoEstoque, IdFuncionarioSolicitador,
                IdFuncionarioAutenticador, IdProduto, Quantidade, DataHora) VALUES
                ({novaMovimentacaoEstoque.IdEstoque}, {novaMovimentacaoEstoque.IdTipoMovimentacaoEstoque},
                {novaMovimentacaoEstoque.IdFuncionarioSolicitador}, {novaMovimentacaoEstoque.IdFuncionarioAutenticador},
                {novaMovimentacaoEstoque.IdProduto}, {novaMovimentacaoEstoque.Quantidade}, '{novaMovimentacaoEstoque.DataHora}')
                ");
            return resultado;
        }

        public static int Alterar(MovimentacaoEstoque movimentacaoEstoqueAlterar)
        {
            var resultado = Update($@"
                UPDATE MovimentacaoEstoque SET
                IdEstoque = {movimentacaoEstoqueAlterar.IdEstoque},
                IdTipoMovimentacaoEstoque = {movimentacaoEstoqueAlterar.IdTipoMovimentacaoEstoque},
                IdFuncionarioSolicitador = {movimentacaoEstoqueAlterar.IdFuncionarioSolicitador},
                IdFuncionarioAutenticador = {movimentacaoEstoqueAlterar.IdFuncionarioAutenticador},
                IdProduto = {movimentacaoEstoqueAlterar.IdProduto},
                Quantidade = {movimentacaoEstoqueAlterar.Quantidade},
                DataHora = '{movimentacaoEstoqueAlterar.DataHora}',
                WHERE IdMovimentacaoEstoque = {movimentacaoEstoqueAlterar.IdMovimentacaoEstoque}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idMovimentacaoEstoque)
        {
            return Update($"DELETE FROM MovimentacoesEstoque WHERE IdMovimentacaoEstoque = {idMovimentacaoEstoque}");
        }
    }
}