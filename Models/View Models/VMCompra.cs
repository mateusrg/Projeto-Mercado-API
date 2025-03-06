namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMCompra
    {
        public int IdCompra { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public string NomeFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
        public string DescricaoProduto { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }

        public VMCompra()
        {
            NomeFornecedor = "";
            CNPJFornecedor = "";
            DescricaoProduto = "";
        }
    }
}
