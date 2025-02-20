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

        public static int Vender(VMVenda novaMovimentacaoEstoque)
        {
            var resultado = Select($@"
                SELECT M.Quantidade FROM MovimentacoesEstoque M WHERE M.IdProduto = ${novaMovimentacaoEstoque.IdProduto} AND M.IdEstoque = ${novaMovimentacaoEstoque.IdEstoque};
            ");

            int quantidadeEmEstoque = 0;
            while (resultado.Read())
            {
                quantidadeEmEstoque += resultado.GetInt32(0);
            }
            resultado.Close();

            if (quantidadeEmEstoque < novaMovimentacaoEstoque.Quantidade)
            {
                return 0;
            }

            var movimentacao = new MovimentacaoEstoque()
            {
                IdFuncionarioSolicitador = novaMovimentacaoEstoque.IdFuncionarioSolicitador,
                IdFuncionarioAutenticador = novaMovimentacaoEstoque.IdFuncionarioAutenticador,
                IdProduto = novaMovimentacaoEstoque.IdProduto,
                Quantidade = Math.Abs(novaMovimentacaoEstoque.Quantidade) * -1,
                DataHora = novaMovimentacaoEstoque.DataHora,
                IdEstoque = 2,
                IdTipoMovimentacaoEstoque = 8
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

        public static List<VMTranserirEstoque> ConsultarPorEstoqueCompleto(int idEstoque)
        {
            List<VMTranserirEstoque> movimentacoesEstoqueCompleto = new List<VMTranserirEstoque>();
            var resultado = Select($"select \r\n E.IdEstoque,\r\n E.Descricao,\r\n E.IdTipoEstoque,\r\n TE.Descricao AS 'TipoEstoque',\r\n ME.IdMovimentacaoEstoque,\r\n ME.IdTipoMovimentacaoEstoque,\r\n Me.IdFuncionarioSolicitador,\r\n ME.idFuncionarioAutenticador,\r\n ME.IdProduto,\r\n ME.Quantidade,\r\n ME.DataHora,\r\n FA.IdFuncionario,\r\n FA.Nome,\r\n FS.IdFuncionario,\r\n FS.Nome,\r\n TME.IdTipoMovimentacaoEstoque,\r\n TME.Descricao,\r\n P.Descricao,\r\n P.CodBarras\r\n from MovimentacoesEstoque ME\r\n  join TiposEstoque TE on ME.IdTipoMovimentacaoEstoque = TE.IdTipoEstoque\r\n  join Estoques E on ME.IdEstoque = E.IdEstoque\r\n  join Funcionarios FA on ME.idFuncionarioAutenticador = FA.IdFuncionario\r\n  join Funcionarios FS on ME.IdFuncionarioSolicitador = FS.IdFuncionario\r\n  join TiposMovimentacaoEstoque TME ON ME.IdTipoMovimentacaoEstoque = TME.IdTipoMovimentacaoEstoque\r\n  join Produtos P on ME.IdProduto = P.IdProduto\r\n where E.IdEstoque = {idEstoque};");
            while (resultado.Read())
            {
                var estoqueCompleto = new VMTranserirEstoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    DescricaoEstoque = resultado.GetString(1),
                    IdTipoEstoque = resultado.GetInt32(2),
                    IdMovimentacaoEstoque = resultado.GetInt32(3),
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(4),
                    IdFuncionarioSolicitador = resultado.GetInt32(5),
                    FuncionarioSolicitador = resultado.GetString(11),
                    IdFuncionarioAutenticador = resultado.GetInt32(6),
                    FuncionarioAutenticador = resultado.GetString(13),
                    IdProduto = resultado.GetInt32(7),
                    Quantidade = resultado.GetInt32(8),
                    DataHora = resultado.GetDateTime(9)
                };
                movimentacoesEstoqueCompleto.Add(estoqueCompleto);
            }
            resultado.Close();
            return movimentacoesEstoqueCompleto;
        }
    }
}