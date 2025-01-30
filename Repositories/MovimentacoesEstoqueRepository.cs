using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

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

        public static int FazerMovimentacao(VWMovimentacaoEstoque movimentacaoEstoque)
        {
            var resultado = Select($@"
                SELECT SUM(me.Quantidade) FROM MovimentacoesEstoque me
                WHERE me.IdProduto = {movimentacaoEstoque.idProduto}
                AND me.IdEstoque = {movimentacaoEstoque.idEstoqueOrigem};
                ");

            int quantidadeEmEstoque = 0;
            while (resultado.Read())
            {
                quantidadeEmEstoque = resultado.GetInt32(0);
            }
            resultado.Close();

            if (quantidadeEmEstoque < movimentacaoEstoque.quantidade)
            {
                return 0;
            }

            var primeiraMovimentacao = new MovimentacaoEstoque()
            {
                IdEstoque = movimentacaoEstoque.idEstoqueOrigem,
                IdTipoMovimentacaoEstoque = movimentacaoEstoque.idTipoMovimentacaoOrigem,
                IdFuncionarioSolicitador = movimentacaoEstoque.idFuncionarioSolicitador,
                IdFuncionarioAutenticador = movimentacaoEstoque.idFuncionarioAutenticador,
                IdProduto = movimentacaoEstoque.idProduto,
                Quantidade = Math.Abs(movimentacaoEstoque.quantidade) * -1,
                DataHora = movimentacaoEstoque.dataHora
            };
            
            var segundaMovimentacao = new MovimentacaoEstoque()
            {
                IdEstoque = movimentacaoEstoque.idEstoqueDestino,
                IdTipoMovimentacaoEstoque = movimentacaoEstoque.idTipoMovimentacaoDestino,
                IdFuncionarioSolicitador = movimentacaoEstoque.idFuncionarioSolicitador,
                IdFuncionarioAutenticador = movimentacaoEstoque.idFuncionarioAutenticador,
                IdProduto = movimentacaoEstoque.idProduto,
                Quantidade = Math.Abs(movimentacaoEstoque.quantidade),
                DataHora = movimentacaoEstoque.dataHora
            };

            Cadastrar(primeiraMovimentacao);
            Cadastrar(segundaMovimentacao);

            return 1;
        }

        public static int Vender(MovimentacaoEstoque vendaEstoque)
        {
            var resultado = Select($@"
                SELECT SUM(me.Quantidade) FROM MovimentacoesEstoque me
                WHERE me.IdProduto = {vendaEstoque.IdProduto}
                AND me.IdEstoque = {vendaEstoque.IdEstoque};
                ");

            int quantidadeEmEstoque = 0;
            while (resultado.Read())
            {
                quantidadeEmEstoque = resultado.GetInt32(0);
            }
            resultado.Close();

            if (quantidadeEmEstoque < vendaEstoque.Quantidade)
            {
                return 0;
            }

            var movimentacao = new MovimentacaoEstoque()
            {
                IdEstoque = vendaEstoque.IdEstoque,
                IdTipoMovimentacaoEstoque = 2,
                IdFuncionarioSolicitador = vendaEstoque.IdFuncionarioSolicitador,
                IdFuncionarioAutenticador = vendaEstoque.IdFuncionarioAutenticador,
                IdProduto = vendaEstoque.IdProduto,
                Quantidade = Math.Abs(vendaEstoque.Quantidade) * -1,
                DataHora = vendaEstoque.DataHora
            };
            Cadastrar(movimentacao);

            return 1;
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