namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMFiltroCompra
    {
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public int? QuantMinima { get; set; }
        public int? QuantMaxima { get; set; }
        public int? IdProduto { get; set; }
        public int? IdFornecedor { get; set; }

        VMFiltroCompra()
        {
            DataInicio = null;
            DataFim = null;
            QuantMinima = null;
            QuantMaxima = null;
            IdProduto = null;
            IdFornecedor = null;
        }
    }
}
