using Projeto_Mercado_API.Models;

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
