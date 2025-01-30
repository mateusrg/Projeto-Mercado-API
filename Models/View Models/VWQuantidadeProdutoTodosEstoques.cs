namespace Projeto_Mercado_API.Models.View_Models
{
    public class VWQuantidadeProdutoTodosEstoques
    {
        public string Estoque { get; set; }
        public int Quantidade { get; set; }

        public VWQuantidadeProdutoTodosEstoques()
        {
            Estoque = "";
            Quantidade = 0;
        }
    }
}
