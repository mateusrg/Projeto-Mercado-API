namespace Projeto_Mercado_API.Models
{
    public class SolicitacaoCompra
    {
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdFuncionarioSolicitador { get; set; }
        public int IdFuncionarioAutenticador { get; set; }
    }
}
