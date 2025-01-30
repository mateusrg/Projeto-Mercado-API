namespace Projeto_Mercado_API.Models.View_Models
{
    public class CompraCompleta
    {
        public int IdCompra { get; set; }
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime Data { get; set; }

        public CompraCompleta()
        {
            IdCompra = 0;
            IdFornecedor = 0;
            IdProduto = 0;
            Data = new DateTime();
            Quantidade = 0;
            Nome = "Sem nome";
            CNPJ = "Sem CNPJ";
            Descricao = "Sem descrição";
        }
    }

}
