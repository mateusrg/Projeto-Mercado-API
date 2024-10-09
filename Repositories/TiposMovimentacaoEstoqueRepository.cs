using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public static List<TipoMovimentacaoEstoque> ListarTodos()
    {
        List<TipoMovimentacaoEstoque> tiposMovimentacaoEstoque = new List<TipoMovimentacaoEstoque>();
        var resultado = Select($"SELECT * FROM Compras");
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

    public static int Cadastrar(TipoMovimentacaoEstoque novoTipoMovimentacaoEstoque)
    {
        return Update($"INSERT INTO TiposMovimentacaoEstoque (Descricao) ('{novoTipoMovimentacaoEstoque.Descricao}')");
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
