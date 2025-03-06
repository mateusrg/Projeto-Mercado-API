namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMMovimentacaoEstoque
    {
        public int? IdMovimentacaoEstoque { get; set; }
        public int? IdEstoque { get; set; }
        public string? DescricaoEstoque { get; set; }
        public int? IdTipoEstoque { get; set; }
        public string? DescricaoTipoEstoque { get; set; }
        public int? IdTipoMovimentacaoEstoque { get; set; }
        public string? DescricaoMovimentacaoEstoque { get; set; }
        public int? IdFuncionarioSolicitador { get; set; }
        public string? NomeFuncionarioSolicitador { get; set; }
        public string? SetorFuncionarioSolicitador { get; set; }
        public string? EmailFuncionarioSolicitador { get; set; }
        public int? IdFuncionarioAutenticador { get; set; }
        public string? NomeFuncionarioAutenticador { get; set; }
        public string? SetorFuncionarioAutenticador { get; set; }
        public string? EmailFuncionarioAutenticador { get; set; }
        public int? IdProduto { get; set; }
        public string? CodBarrasProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public int? Quantidade { get; set; }
        public DateTime DataHora { get; set; }
    
        public VMMovimentacaoEstoque()
        {
            DataHora = new DateTime();
        }
    }
}
