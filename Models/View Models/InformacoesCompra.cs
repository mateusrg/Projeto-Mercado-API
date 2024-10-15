namespace Projeto_Mercado_API.Models.View_Models
{
    public class InformacoesCompra
    {
        public int IdCompra { get; set; }
        public string Fornecedor { get; set; }
        public string Produto { get; set; }
        public string Data { get; set; }
        public int Quantidade { get; set; }

        public InformacoesCompra()
        {
            Fornecedor = "";
            Produto = "";
            Data = "";
            Quantidade = 0;
        }
    }
}