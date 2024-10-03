namespace Projeto_Mercado_API.Models
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }

        public Fornecedor()
        {
            IdFornecedor = 0;
            CNPJ = "";
            Nome = "";
        }
    }
}