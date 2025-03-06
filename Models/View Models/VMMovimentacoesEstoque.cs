namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMMovimentacoesEstoque
    {
        public int idProduto { get; set; }
        public int quantidade { get; set; }
        public int idEstoqueOrigem { get; set; }
        public int idEstoqueDestino { get; set; }
        public int idFuncionarioSolicitador { get; set; }
        public int idFuncionarioAutenticador { get; set; }
        public int idTipoMovimentacaoOrigem { get; set; }
        public int idTipoMovimentacaoDestino { get; set; }
        public DateTime dataHora { get; set; }

        public VMMovimentacoesEstoque()
        {
            idProduto = 0;
            quantidade = 0;
            idEstoqueOrigem = 0;
            idEstoqueDestino = 0;
            idFuncionarioSolicitador = 0;
            idFuncionarioAutenticador = 0;
            idTipoMovimentacaoOrigem = 0;
            idTipoMovimentacaoDestino = 0;
            dataHora = DateTime.Now;
        }
    }
}
