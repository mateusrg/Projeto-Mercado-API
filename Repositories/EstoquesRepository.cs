using Projeto_Mercado_API.Models;

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
