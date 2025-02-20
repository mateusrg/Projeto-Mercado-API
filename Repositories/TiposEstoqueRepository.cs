using Projeto_Mercado_API.Models;

namespace Projeto_Mercado_API.Repositories
{
    public class TiposEstoqueRepository : RepositoryBase
    {
        public static List<TipoEstoque> ListarTodos()
        {
            List<TipoEstoque> tiposEstoque = new List<TipoEstoque>();
            var resultado = Select($"SELECT * FROM TiposEstoque");
            while (resultado.Read())
            {
                var tipoEstoque = new TipoEstoque()
                {
                    IdTipoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                tiposEstoque.Add(tipoEstoque);
            }
            resultado.Close();
            return tiposEstoque;
        }

        public static TipoEstoque? ConsultarPorId(int idTipoEstoque)
        {
            var resultado = Select($"SELECT * FROM TiposEstoque WHERE IdTipoEstoque = {idTipoEstoque}");
            if (resultado.Read())
            {
                var tipoEstoque = new TipoEstoque()
                {
                    IdTipoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                resultado.Close();
                return tipoEstoque;
            }
            resultado.Close();
            return null;
        }

        public static List<TipoEstoque> ConsultarPorDescricao(string descricao)
        {
            List<TipoEstoque> tiposEstoque = new List<TipoEstoque>();
            var resultado = Select($"SELECT * FROM TiposEstoque WHERE Descricao LIKE '%{descricao}%'");
            while (resultado.Read())
            {
                var tipoEstoque = new TipoEstoque()
                {
                    IdTipoEstoque = resultado.GetInt32(0),
                    Descricao = resultado.GetString(1)
                };
                tiposEstoque.Add(tipoEstoque);
            }
            resultado.Close();
            return tiposEstoque;
        }

        public static int Cadastrar(TipoEstoque novoTipoEstoque)
        {
            return Update($"INSERT INTO TiposEstoque (Descricao) VALUES ('{novoTipoEstoque.Descricao}')");
        }

        public static int Alterar(TipoEstoque tipoEstoqueAlterar)
        {
            var resultado = Update($@"
                UPDATE TiposEstoque SET
                Descricao = '{tipoEstoqueAlterar.Descricao}'
                WHERE IdTipoEstoque = {tipoEstoqueAlterar.IdTipoEstoque}
                ");
            return resultado;
        }

        public static int ExcluirPorId(int idTipoEstoque)
        {
            return Update($"DELETE FROM TiposEstoque WHERE IdTipoEstoque = {idTipoEstoque}");
        }
    }
}