using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

namespace Projeto_Mercado_API.Repositories
{
    public class FornecedoresRepository : RepositoryBase
    {
        public static List<Fornecedor> ListarTodos()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            var resultado = Select($"SELECT * FROM Fornecedores");
            while (resultado.Read())
            {
                var fornecedor = new Fornecedor()
                {
                    IdFornecedor = resultado.GetInt32(0),
                    CNPJ = resultado.GetString(1),
                    Nome = resultado.GetString(2)
                };
                fornecedores.Add(fornecedor);
            }
            resultado.Close();
            return fornecedores;
        }

        public static List<VMCompra> ListarComprasDoFornecedor(int idFornecedor)
        {
            List<VMCompra> compras = [];
            var resultado = Select($@"
                SELECT *
                FROM Compras C
                JOIN Fornecedores F ON C.IdFornecedor = F.IdFornecedor
                JOIN Produtos P ON C.IdProduto = P.IdProduto
                WHERE C.IdFornecedor = {idFornecedor}
                ORDER BY C.IdCompra DESC
                ");
            while (resultado.Read())
            {
                var compra = new VMCompra()
                {
                    IdCompra = resultado.GetInt32(0),
                    IdFornecedor = resultado.GetInt32(1),
                    IdProduto = resultado.GetInt32(2),
                    NomeFornecedor = resultado.GetString(7),
                    CNPJFornecedor = resultado.GetString(6),
                    CodBarrasProduto = resultado.GetString(9),
                    DescricaoProduto = resultado.GetString(10),
                    Data = resultado.GetDateTime(3),
                    Quantidade = resultado.GetInt32(4)
                };
                compras.Add(compra);
            }
            resultado.Close();
            return compras;
        }


        public static Fornecedor? ConsultarPorId(int idFornecedor)
        {
            var resultado = Select($"SELECT * FROM Fornecedores WHERE IdFornecedor = {idFornecedor}");
            if (resultado.Read())
            {
                var fornecedor = new Fornecedor()
                {
                    IdFornecedor = resultado.GetInt32(0),
                    CNPJ = resultado.GetString(1),
                    Nome = resultado.GetString(2)
                };
                resultado.Close();
                return fornecedor;
            }
            resultado.Close();
            return null;
        }

        public static Fornecedor? ConsultarPorCNPJ(string CNPJ)
        {
            var resultado = Select($"SELECT * FROM Fornecedores WHERE CNPJ = '{CNPJ}'");
            if (resultado.Read())
            {
                var fornecedor = new Fornecedor()
                {
                    IdFornecedor = resultado.GetInt32(0),
                    CNPJ = resultado.GetString(1),
                    Nome = resultado.GetString(2)
                };
                resultado.Close();
                return fornecedor;
            }
            resultado.Close();
            return null;
        }

        public static List<Fornecedor> ConsultarPorNome(string nome)
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            var resultado = Select($"SELECT * FROM Fornecedores WHERE Nome LIKE '%{nome}%'");
            while (resultado.Read())
            {
                var fornecedor = new Fornecedor()
                {
                    IdFornecedor = resultado.GetInt32(0),
                    CNPJ = resultado.GetString(1),
                    Nome = resultado.GetString(2)
                };
                fornecedores.Add(fornecedor);
            }
            resultado.Close();
            return fornecedores;
        }

        public static List<Fornecedor> ConsultarPorNomeECNPJ(string texto)
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            var resultado = Select($@"SELECT * 
                            FROM Fornecedores 
                            WHERE 
                                Nome LIKE '%{texto}%' OR
                                CNPJ LIKE '%{texto}%' OR
                                REPLACE(REPLACE(REPLACE(REPLACE(CNPJ, '.', ''), '/', ''), '-', ''), ' ', '')
                                LIKE '%{texto}%'");
            while (resultado.Read())
            {
                var fornecedor = new Fornecedor()
                {
                    IdFornecedor = resultado.GetInt32(0),
                    CNPJ = resultado.GetString(1),
                    Nome = resultado.GetString(2)
                };
                fornecedores.Add(fornecedor);
            }
            resultado.Close();
            return fornecedores;
        }

        public static int Cadastrar(Fornecedor novoFornecedor)
        {
            var resultado = Update($@"
                INSERT INTO Fornecedores (CNPJ, Nome) VALUES
                ('{novoFornecedor.CNPJ}', '{novoFornecedor.Nome}')
                ");
            return resultado;
        }

        public static int Alterar(Fornecedor fornecedorAlterar)
        {
            var resultado = Update($@"
                UPDATE Fornecedores SET
                CNPJ = '{fornecedorAlterar.CNPJ}',
                Nome = '{fornecedorAlterar.Nome}'
                WHERE IdFornecedor = {fornecedorAlterar.IdFornecedor}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idFornecedor)
        {
            return Update($"DELETE FROM Fornecedores WHERE IdFornecedor = {idFornecedor}");
        }
    }
}
