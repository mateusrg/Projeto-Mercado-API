namespace Projeto_Mercado_API.Models.View_Models
{
    public class VWQuantidadeProdutoEstoque
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }

        public VWQuantidadeProdutoEstoque()
        {
            Produto = "";
            Quantidade = 0;
        }
    }
}
