namespace Projeto_Mercado_API.Models.View_Models
{
    public class VWQuantidadeProdutoEstoque
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        public string CodBarras { get; set; }

        public VWQuantidadeProdutoEstoque()
        {
            Produto = "";
            CodBarras = "";
            IdProduto = 0;
            Quantidade = 0;
        }
    }
}
