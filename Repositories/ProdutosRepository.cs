using Projeto_Mercado_API.Models;

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
                                    {(int.TryParse(texto, out _) ? "IdProduto = {texto} OR" : "")}
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
