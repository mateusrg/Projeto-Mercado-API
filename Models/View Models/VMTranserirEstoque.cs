namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMTranserirEstoque
    {
        public int IdMovimentacaoEstoque { get; set; }
        public int IdTipoMovimentacaoEstoque { get; set; }
        public int DescricaoTipoMovimentacaoEstoque { get; set; }
        public int IdEstoque { get; set; }
        public string DescricaoEstoque { get; set; }
        public int IdTipoEstoque { get; set; }
        public string DescricaoTipoEstoque { get; set; }
        public int IdFuncionarioSolicitador { get; set; }
        public string FuncionarioSolicitador { get; set; }
        public int IdFuncionarioAutenticador { get; set; }
        public string FuncionarioAutenticador{ get; set; }
        public int IdProduto { get; set; }
        public string CodBarras { get; set; }
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
