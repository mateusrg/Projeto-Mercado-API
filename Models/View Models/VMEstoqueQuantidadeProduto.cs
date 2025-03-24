namespace Projeto_Mercado_API.Models.View_Models
{
    public class VMEstoqueQuantidadeProduto
    {
        public string Estoque { get; set; }
        public int Quantidade { get; set; }

        public VMEstoqueQuantidadeProduto()
        {
            Estoque = "";
            Quantidade = 0;
        }
    }
}
