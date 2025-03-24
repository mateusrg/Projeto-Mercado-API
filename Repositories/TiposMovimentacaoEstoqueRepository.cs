using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;

namespace Projeto_Mercado_API.Repositories
{
    public class TiposMovimentacaoEstoqueRepository : RepositoryBase
    {
        public static List<TipoMovimentacaoEstoque> ListarTodos()
        {
            List<TipoMovimentacaoEstoque> tiposMovimentacaoEstoque = new List<TipoMovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM TiposMovimentacaoEstoque");
            while (resultado.Read())
            {
                var tipoMovimentacaoEstoque = new TipoMovimentacaoEstoque()
                {
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                tiposMovimentacaoEstoque.Add(tipoMovimentacaoEstoque);
            }
            resultado.Close();
            return tiposMovimentacaoEstoque;
        }

        public static TipoMovimentacaoEstoque? ConsultarPorId(int idTipoMovimentaoEstoque)
        {
            var resultado = Select($"SELECT * FROM TiposMovimentacaoEstoque WHERE IdTipoMovimentacaoEstoque = {idTipoMovimentaoEstoque}");
            if (resultado.Read())
            {
                var tipoMovimentacaoEstoque = new TipoMovimentacaoEstoque()
                {
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                resultado.Close();
                return tipoMovimentacaoEstoque;
            }
            resultado.Close();
            return null;
        }

        public static List<TipoMovimentacaoEstoque> ConsultarPorDescricao(string descricao)
        {
            List<TipoMovimentacaoEstoque> tiposMovimentacaoEstoque = new List<TipoMovimentacaoEstoque>();
            var resultado = Select($"SELECT * FROM TiposMovimentacaoEstoque WHERE Descricao LIKE '%{descricao}%'");
            while (resultado.Read())
            {
                var tipoMovimentacaoEstoque = new TipoMovimentacaoEstoque()
                {
                    IdTipoMovimentacaoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                tiposMovimentacaoEstoque.Add(tipoMovimentacaoEstoque);
            }
            resultado.Close();
            return tiposMovimentacaoEstoque;
        }

        public static List<VMMovimentacaoEstoque> ListarMovimentacoesPorTipo(int idTipoMovimentacao)
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
                WHERE me.IdTipoMovimentacaoEstoque = {idTipoMovimentacao}
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

        public static int Cadastrar(TipoMovimentacaoEstoque novoTipoMovimentacaoEstoque)
        {
            return Update($"INSERT INTO TiposMovimentacaoEstoque (Descricao) VALUES ('{novoTipoMovimentacaoEstoque.Descricao}')");
        }

        public static int Alterar(TipoMovimentacaoEstoque tipoMovimentacaoEstoqueAlterar)
        {
            var resultado = Update($@"
                UPDATE TiposMovimentacaoEstoque SET
                Descricao = '{tipoMovimentacaoEstoqueAlterar.Descricao}'
                WHERE IdTipoMovimentacaoEstoque = {tipoMovimentacaoEstoqueAlterar.IdTipoMovimentacaoEstoque}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idTipoMovimentacaoEstoque)
        {
            return Update($"DELETE FROM TiposMovimentacaoEstoque WHERE IdTipoMovimentacaoEstoque = {idTipoMovimentacaoEstoque}");
        }
    }
}
