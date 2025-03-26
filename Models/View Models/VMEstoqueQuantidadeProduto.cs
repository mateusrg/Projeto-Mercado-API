namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMEstoqueQuantidadeProduto
    {
        public string Estoque { get; set; }
        public string TipoEstoque { get; set; }
        public int Quantidade { get; set; }
        public int IdEstoque { get; set; }
        public int IdTipoEstoque { get; set; }

        public VMEstoqueQuantidadeProduto()
        {
            Estoque = "";
            TipoEstoque = "";
            Quantidade = 0;
            IdEstoque = 0;
            IdTipoEstoque = 0;
        }
    }
}
