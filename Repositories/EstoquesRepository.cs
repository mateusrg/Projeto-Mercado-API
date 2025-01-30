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
