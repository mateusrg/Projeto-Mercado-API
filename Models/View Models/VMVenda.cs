namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMVenda
    {
        public int IdMovimentacaoEstoque { get; set; }
        public int IdFuncionarioSolicitador { get; set; }
        public int IdFuncionarioAutenticador { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
