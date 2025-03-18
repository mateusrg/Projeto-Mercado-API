using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

namespace Projeto_Mercado_API.Repositories
{
    public class EstoquesRepository : RepositoryBase
    {
        public static List<Estoque> ListarTodos()
        {
            List<Estoque> estoques = new List<Estoque>();
            var resultado = Select($"SELECT * FROM Estoques");
            while (resultado.Read())
            {
                var estoque = new Estoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    IdTipoEstoque = resultado.GetInt32(1),
                    Descricao = resultado.GetString(2)
                };
                estoques.Add(estoque);
            }
            resultado.Close();
            return estoques;
        }
        public static Estoque? ConsultarPorId(int idEstoque)
        {
            var resultado = Select($"SELECT * FROM Estoques WHERE IdEstoque = {idEstoque}");
            if (resultado.Read())
            {
                var estoque = new Estoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    IdTipoEstoque = resultado.GetInt32(1),
                    Descricao = resultado.GetString(2)
                };
                resultado.Close();
                return estoque;
            }
            resultado.Close();
            return null;
        }

        public static Estoque? ConsultarPorTipoEstoque(int idTipoEstoque)
        {
            var resultado = Select($"SELECT * FROM Estoques WHERE IdTipoEstoque = {idTipoEstoque}");
            if (resultado.Read())
            {
                var estoque = new Estoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    IdTipoEstoque = resultado.GetInt32(1),
                    Descricao = resultado.GetString(2)
                };
                resultado.Close();
                return estoque;
            }
            resultado.Close();
            return null;
        }

        public static List<Estoque> ConsultarPorDescricao(string descricao)
        {
            List<Estoque> estoques = new List<Estoque>();
            var resultado = Select($"SELECT * FROM Estoques WHERE Descricao LIKE '%{descricao}%'");
            while (resultado.Read())
            {
                var estoque = new Estoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    IdTipoEstoque = resultado.GetInt32(1),
                    Descricao = resultado.GetString(2)
                };
                estoques.Add(estoque);
            }
            resultado.Close();
            return estoques;
        }

        public static List<VWQuantidadeProdutoEstoque> ConsultarPorQuantProdutosNoEstoque(int idEstoque)
        {
            List<VWQuantidadeProdutoEstoque> quantidadeProdutosEstoque = [];
            var resultado = Select($@"
                SELECT p.Descricao AS Produto,
                SUM(me.Quantidade) AS Quantidade
                FROM MovimentacoesEstoque me
                LEFT JOIN Produtos p ON me.IdProduto = p.IdProduto
                LEFT JOIN Estoques e ON e.IdEstoque = me.IdEstoque
                WHERE me.IdEstoque = {idEstoque}
                GROUP BY p.Descricao;
                ");
            while (resultado.Read())
            {
                var quantidadeProdutoEstoque = new VWQuantidadeProdutoEstoque()
                {
                    Produto = resultado.GetString(0),
                    Quantidade = resultado.GetInt32(1),
                };
                quantidadeProdutosEstoque.Add(quantidadeProdutoEstoque);
            }
            resultado.Close();
            return quantidadeProdutosEstoque;
        }

        public static List<VMMovimentacaoEstoque> ListarMovimentacoesRecentes(int idEstoque)
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
                WHERE me.IdEstoque = {idEstoque}
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


        public static List<VWQuantidadeProdutoTodosEstoques> ConsultarQuantProdutoEmTodosEstoques(string codBarras)
        {
            List<VWQuantidadeProdutoTodosEstoques> quantidadeProdutosTodosEstoques = [];
            var resultado = Select($@"
                SELECT e.Descricao AS Estoque,
                SUM(me.Quantidade) AS Quantidade
                FROM MovimentacoesEstoque me
                LEFT JOIN Produtos p ON me.IdProduto = p.IdProduto
                LEFT JOIN Estoques e ON e.IdEstoque = me.IdEstoque
                WHERE me.IdProduto =
                (SELECT pr.IdProduto FROM Produtos pr WHERE pr.CodBarras = '{codBarras}')
                GROUP BY e.Descricao;
                ");
            while (resultado.Read())
            {
                var quantidadeProdutoTodosEstoques = new VWQuantidadeProdutoTodosEstoques()
                {
                    Estoque = resultado.GetString(0),
                    Quantidade = resultado.GetInt32(1),
                };
                quantidadeProdutosTodosEstoques.Add(quantidadeProdutoTodosEstoques);
            }
            resultado.Close();
            return quantidadeProdutosTodosEstoques;
        }

        public static List<VMEstoque> ConsultarIdTipoEstoqueEstoqueTipoEstoque(int? idTipoEstoque, string? descricao)
        {
            var estoques = new List<VMEstoque>();
            var resultado = Select($@"SELECT 
                            e.IdEstoque, e.Descricao,
                            t.Descricao FROM Estoques e
                            JOIN TiposEstoque t
                            ON e.IdTipoEstoque = t.IdTipoEstoque
                            WHERE 1=1
                            {(idTipoEstoque == null ? "" : $"AND e.IdTipoEstoque = {idTipoEstoque}")}
                            {(descricao == null ? "" : $"AND e.Descricao LIKE '%{descricao}%'")}");
            while (resultado.Read())
            {
                var estoque = new VMEstoque()
                {
                    IdEstoque = resultado.GetInt32(0),
                    DescricaoEstoque = resultado.GetString(1),
                    DescricaoTipoEstoque = resultado.GetString(2),
                };
                estoques.Add(estoque);
            }
            resultado.Close();
            return estoques;
        }

        public static int Cadastrar(Estoque novoEstoque)
        {
            var resultado = Update($@"
                INSERT INTO Estoques (IdTipoEstoque, Descricao) VALUES
                ({novoEstoque.IdTipoEstoque}, '{novoEstoque.Descricao}')
                ");
            return resultado;
        }

        public static int Alterar(Estoque estoqueAlterar)
        {
            var resultado = Update($@"
                UPDATE Estoques SET
                IdTipoEstoque = {estoqueAlterar.IdTipoEstoque},
                Descricao = '{estoqueAlterar.Descricao}',
                WHERE IdEstoque = {estoqueAlterar.IdEstoque}
                ");
            return resultado;
        }
    }
}