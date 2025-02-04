namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMEstoques
    {
        public int IdMovimentacaoEstoque { get; set; }
        public int IdTipoMovimentacaoEstoque { get; set; }
        public int DescricaoTME { get; set; }
        public int IdEstoque { get; set; }
        public string DescricaoE { get; set; }
        public int IdTipoEstoque { get; set; }
        public string DescricaoTE { get; set; }
        public int IdFuncionarioSolicitador { get; set; }
        public string NomeSolicitador { get; set; }
        public int IdFuncionarioAutenticador { get; set; }
        public string NomeAutenticador{ get; set; }
        public int IdProduto { get; set; }
        public string CodBarras { get; set; }
        public string DescricaoP { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
