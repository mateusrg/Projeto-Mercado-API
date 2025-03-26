namespace Projeto_Mercado_API.Models.View_Models
{
    public class FiltroParaMovimentacaoEstoque
    {
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public int? QuantidadeMinima { get; set; }
        public int? QuantidadeMaxima { get; set; }
        public int? IdProduto { get; set; }
        public int? IdEstoque { get; set; }
        public int? IdTipoMovimentacaoEstoque { get; set; }
    }
}
