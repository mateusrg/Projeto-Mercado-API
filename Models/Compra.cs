namespace Projeto_Mercado_API.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public string Data { get; set; }
        public int Quantidade { get; set; }

        public Compra()
        {
            IdCompra = 0;
            IdFornecedor = 0;
            IdProduto = 0;
            Data = "";
            Quantidade = 0;
        }
    }
}
