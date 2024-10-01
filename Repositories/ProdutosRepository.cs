using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public class ProdutosRepository : RepositoryBase
    {
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

        public static Produto? ConsultarPorCodBarras(int codBarras)
        {
            var resultado = Select($"SELECT * FROM Produtos WHERE CodBarras = {codBarras}");
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
            var resultado = Select($"SELECT * FROM Produtos WHERE Descricao LIKE %{descricao}%");
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

        public static int ExcluirPorId (int idProduto)
        {
            return Update($"DELETE FROM Produtos WHERE idProduto = {idProduto}");
        }

        public static int Cadastrar (Produto novoProduto)
        {
            var resultado = Update($@"
                INSERT INTO Produtos (CodBarras, Descricao) VALUES
                ({novoProduto.CodBarras}, {novoProduto.Descricao})
                ");
            return resultado;
        }

        public static int Alterar(Produto produtoAlterar)
        {
            var resultado = Update($@"
                UPDATE Produtos SET
                CodBarras = {produtoAlterar.CodBarras},
                Descricao = {produtoAlterar.Descricao},
                WHERE IdProduto = {produtoAlterar.IdProduto}
                ");
            return resultado;
        }
    }
}
