namespace Projeto_Mercado_API.Models.View_Models
{
    public class FiltroParaCompra
    {
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public int? QuantMinima { get; set; }
        public int? QuantMaxima { get; set; }
        public int? IdProduto { get; set; }
        public int? IdFornecedor { get; set; }
    }
}