using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

namespace Projeto_Mercado_API.Repositories
{
    public class ProdutosRepository : RepositoryBase
    {
        public static List<Produto> ListarTodos()
        {
            List<Produto> produtos = new List<Produto>();
            var resultado = Select($"SELECT * FROM Produtos");
            while (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                produtos.Add(produto);
            }
            resultado.Close();
            return produtos;
        }

        public static List<VMEstoqueQuantidadeProduto> ListarQuantidadePorEstoque(int idProduto)
        {
            List<VMEstoqueQuantidadeProduto> quantidadeProdutosEstoque = [];
            var resultado = Select($@"
                SELECT e.Descricao AS Estoque,
                SUM(me.Quantidade) AS Quantidade,
                e.IdEstoque, e.IdTipoEstoque, t.Descricao
                FROM MovimentacoesEstoque me
                LEFT JOIN Produtos p ON me.IdProduto = p.IdProduto
                LEFT JOIN Estoques e ON e.IdEstoque = me.IdEstoque
                LEFT JOIN TiposEstoque t ON e.IdTipoEstoque = t.IdTipoEstoque
                WHERE me.IdProduto = {idProduto}
                GROUP BY e.Descricao, e.IdEstoque, e.IdTipoEstoque, t.Descricao
            ");

            while (resultado.Read())
            {
                var quantidadeProdutoEstoque = new VMEstoqueQuantidadeProduto()
                {
                    Estoque = resultado.GetString(0),
                    Quantidade = resultado.GetInt32(1),
                    IdEstoque = resultado.GetInt32(2),
                    IdTipoEstoque = resultado.GetInt32(3),
                    TipoEstoque = resultado.GetString(4)
                };
                quantidadeProdutosEstoque.Add(quantidadeProdutoEstoque);
            }
            resultado.Close();
            return quantidadeProdutosEstoque;
        }

        public static List<VMMovimentacaoEstoque> ListarMovimentacoesRecentes(int idProduto)
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
                WHERE me.IdProduto = {idProduto}
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

        public static Produto? ConsultarPorId(int idProduto)
        {
            var resultado = Select($"SELECT * FROM Produtos WHERE IdProduto = {idProduto}");
            if (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                resultado.Close();
                return produto;
            }
            resultado.Close();
            return null;
        }

        public static Produto? ConsultarPorCodBarras(string codBarras)
        {
            var resultado = Select($"SELECT * FROM Produtos WHERE CodBarras = '{codBarras}'");
            if (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                resultado.Close();
                return produto;
            }
            resultado.Close();
            return null;
        }

        public static List<Produto> ConsultarPorDescricao(string descricao)
        {
            List<Produto> produtos = new List<Produto>();
            var resultado = Select($"SELECT * FROM Produtos WHERE Descricao LIKE '%{descricao}%'");
            while (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                produtos.Add(produto);
            }
            resultado.Close();
            return produtos;
        }

        public static List<Produto> ConsultarPorDescricaoECodBarras(string texto)
        {
            List<Produto> produtos = new List<Produto>();
            var resultado = Select($@"SELECT * 
                                    FROM Produtos 
                                    WHERE 
                                    Descricao LIKE '%{texto}%' OR
                                    CodBarras LIKE '%{texto}%'");
            while (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                produtos.Add(produto);
            }
            resultado.Close();
            return produtos;
        }

        public static List<Produto> ConsultarPorTudo(string texto)
        {
            List<Produto> produtos = new List<Produto>();
            var resultado = Select($@"SELECT * 
                                    FROM Produtos 
                                    WHERE 
                                    {(int.TryParse(texto, out _) ? $"IdProduto = {texto} OR" : "")}
                                    Descricao LIKE '%{texto}%' OR
                                    CodBarras LIKE '%{texto}%'");
            while (resultado.Read())
            {
                var produto = new Produto()
                {
                    IdProduto = resultado.GetInt32(0),
                    CodBarras = resultado.GetString(1),
                    Descricao = resultado.GetString(2)
                };
                produtos.Add(produto);
            }
            resultado.Close();
            return produtos;
        }

        public static int ExcluirPorId(int idProduto)
        {
            try
            {
                return Update($"DELETE FROM Produtos WHERE IdProduto = {idProduto}");
            }
            catch
            {
                return 0;
            }
        }

        public static int Cadastrar(Produto novoProduto)
        {
            try
            {
                var resultado = Update($@"
                    INSERT INTO Produtos (CodBarras, Descricao) VALUES
                    ('{novoProduto.CodBarras}', '{novoProduto.Descricao}')
                    ");
                return resultado;
            }
            catch
            {
                return 0;
            }
        }

        public static int Alterar(Produto produtoAlterar)
        {
            try
            {
                var resultado = Update($@"
                    UPDATE Produtos SET
                    CodBarras = '{produtoAlterar.CodBarras}',
                    Descricao = '{produtoAlterar.Descricao}'
                    WHERE IdProduto = {produtoAlterar.IdProduto}
                    ");
                return resultado;
            }
            catch
            {
                return 0;
            }
        }
    }
}
