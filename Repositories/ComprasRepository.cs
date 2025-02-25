using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;
using System.Globalization;

namespace Projeto_Mercado_API.Repositories
{
    public class ComprasRepository : RepositoryBase
    {
        public static List<InformacoesCompra> ListarTodosView()
        {
            List<InformacoesCompra> compras = new List<InformacoesCompra>();
            var resultado = Select($@"
                SELECT C.IdCompra, F.IdFornecedor, P.IdProduto, F.Nome, P.Descricao, C.Data, C.Quantidade
                FROM Compras C
                JOIN Fornecedores F ON C.IdFornecedor = F.IdFornecedor
                JOIN Produtos P ON C.IdProduto = P.IdProduto;
                ");
            while (resultado.Read())
            {
                var compra = new InformacoesCompra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Fornecedor = resultado.GetString(3),
                    Produto = resultado.GetString(4),
                    Data = resultado.GetDateTime(5).ToString("dd/MM/yyyy"),
                    Quantidade = resultado.GetInt32(6)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static int CadastrarView(InformacoesCompra novaCompra)
        {
            var resultado = Update($@"
                INSERT INTO Compras (IdFornecedor, IdProduto, Data, Quantidade) VALUES
                ((SELECT IdFornecedor FROM Fornecedores WHERE Nome = '{novaCompra.Fornecedor}'),
                (SELECT IdProduto FROM Produtos WHERE Descricao = '{novaCompra.Produto}'),
                (CONVERT(smalldatetime, '{novaCompra.Data}', 121)),
                {novaCompra.Quantidade})
                ");
            return resultado;
        }

        public static int AlterarView(InformacoesCompra compraAlterar)
        {
            var resultado = Update($@"
                UPDATE Compras SET
                IdFornecedor = (SELECT IdFornecedor FROM Fornecedores WHERE Nome = '{compraAlterar.Fornecedor}'),
                IdProduto = (SELECT IdProduto FROM Produtos WHERE Descricao = '{compraAlterar.Produto}'),
                Data = (CONVERT(smalldatetime, '{compraAlterar.Data}', 121)),
                Quantidade = {compraAlterar.Quantidade}
                WHERE IdCompra = {compraAlterar.IdCompra}
                ");
            return resultado;
        }

        public static List<Compra> ListarTodos()
        {
            List<Compra> compras = new List<Compra>();
            var resultado = Select($"SELECT * FROM Compras");
            while (resultado.Read())
            {
                var compra = new Compra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static Compra? ConsultarPorId(int idCompra)
        {
            var resultado = Select($"SELECT * FROM Compras WHERE IdCompra = {idCompra}");
            if (resultado.Read())
            {
                var compra = new Compra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                resultado.Close();
                return compra;
            }
            resultado.Close();
            return null;
        }

        public static List<Compra> ConsultarPorIdFornecedor(int idFornecedor)
        {
            List<Compra> compras = new List<Compra>();
            var resultado = Select($"SELECT * FROM Compras WHERE IdFornecedor = {idFornecedor}");
            while (resultado.Read())
            {
                var compra = new Compra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static List<Compra> ConsultarPorIdProduto(int idProduto)
        {
            List<Compra> compras = new List<Compra>();
            var resultado = Select($"SELECT * FROM Compras WHERE IdProduto = {idProduto}");
            while (resultado.Read())
            {
                var compra = new Compra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static List<Compra> ConsultarPorData(string dataInicio, string dataFim)
        {
            List<Compra> compras = new List<Compra>();
            var resultado = Select($"SELECT * FROM Compras WHERE Data >= '{dataInicio}' AND Data <= '{dataFim}'");
            while (resultado.Read())
            {
                var compra = new Compra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static List<VMCompra> ConsultarPorTudo(FiltroParaCompra filtroCompra)
        {
            List<VMCompra> compras = [];
            var resultado = Select($@"SELECT * FROM Compras c
                LEFT JOIN Produtos p
                ON c.IdProduto = p.IdProduto
                LEFT JOIN Fornecedores f
                ON c.IdFornecedor = f.IdFornecedor
                WHERE 1=1
                {(filtroCompra.DataInicio == null ? "" : $"AND Data >= '{filtroCompra.DataInicio}'")}
                {(filtroCompra.DataFim == null ? "" : $"AND Data <= '{filtroCompra.DataFim}'")}
                {(filtroCompra.QuantMinima == null ? "" : $"AND c.Quantidade >= {filtroCompra.QuantMinima}")}
                {(filtroCompra.QuantMaxima == null ? "" : $"AND c.Quantidade <= {filtroCompra.QuantMaxima}")}
                {(filtroCompra.IdProduto == null ? "": $"AND c.IdProduto = {filtroCompra.IdProduto}")}
                {(filtroCompra.IdFornecedor == null ? "" : $"AND c.IdFornecedor = {filtroCompra.IdFornecedor}")}
                ");
            while (resultado.Read())
            {
                var compra = new VMCompra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    NomeFornecedor = resultado.GetString(10),
                    CNPJFornecedor = resultado.GetString(9),
                    DescricaoProduto = resultado.GetString(7),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }

        public static int Cadastrar(Compra novaCompra)
        {
            var resultado = Update($@"
                INSERT INTO Compras (IdFornecedor, IdProduto, Data, Quantidade) VALUES
                ({novaCompra.IdFornecedor}, {novaCompra.IdProduto}, '{novaCompra.Data}', {novaCompra.Quantidade})
                ");
            return resultado;
        }

        public static int Alterar(Compra compraAlterar)
        {
            var resultado = Update($@"
                UPDATE Compras SET
                IdFornecedor = {compraAlterar.IdFornecedor},
                IdProduto = {compraAlterar.IdProduto},
                Data = '{compraAlterar.Data}',
                Quantidade = {compraAlterar.Quantidade}
                WHERE IdCompra = {compraAlterar.IdCompra}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idCompra)
        {
            return Update($"DELETE FROM Compras WHERE IdCompra = {idCompra}");
        }
        public static CompraCompleta CCC(int IdCompra)
        {
            var resultado = Select($@"select 
                      C.IdCompra,
                      C.IdProduto,
                      P.Descricao,
                      C.Quantidade,
                      C.IdFornecedor,
                      F.Nome,
                      F.CNPJ,
                      C.Data
                      from Compras C
                      left join Produtos P on C.IdProduto = P.IdProduto
                      left join Fornecedores F on C.IdFornecedor = F.IdFornecedor
                      where C.IdCompra = {IdCompra}");
            if (resultado.Read())
            {
                var compraCompleta = new CompraCompleta()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdProduto = resultado.GetInt32(1),
                    Descricao = resultado.GetString(2),
                    Quantidade = resultado.GetInt32(3),
                    IdFornecedor = resultado.GetInt32(4),
                    Nome = resultado.GetString(5),
                    CNPJ = resultado.GetString(6),
                    Data = resultado.GetDateTime(7)

                };
                resultado.Close();
                return compraCompleta;
            }
            resultado.Close();
            return null;
        }

    }
}