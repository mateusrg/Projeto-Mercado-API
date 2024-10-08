namespace Projeto_Mercado_API.Models
{
    public class MovimentacaoEstoque
    {
        public int IdMovimentacaoEstoque { get; set; }
        public int IdEstoque { get; set; }
        public int IdTipoMovimentacaoEstoque { get; set; }
        public int IdFuncionarioSolicitador { get; set; }
        public int IdFuncionarioAutenticador { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }

        public MovimentacaoEstoque()
        {
            IdMovimentacaoEstoque = 0;
            IdEstoque = 0;
            IdTipoMovimentacaoEstoque = 0;
            IdFuncionarioSolicitador = 0;
            IdFuncionarioAutenticador = 0;
            IdProduto = 0;
            Quantidade = 0;
            DataHora = new DateTime();
        }
    }
}
