namespace Projeto_Mercado_API.Models
{
    public class TipoMovimentacaoEstoque
    {
        public int IdTipoMovimentacaoEstoque { get; set; }
        public string Descricao { get; set; }
        public TipoMovimentacaoEstoque() 
        {
            IdTipoMovimentacaoEstoque = 0;
            Descricao = "";
        }
    }
}

