namespace Projeto_Mercado_API.Models
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public int IdTipoEstoque { get; set; }
        public string Descricao { get; set; }

        public Estoque()
        {
            IdEstoque = 0;
            IdTipoEstoque = 0;
            Descricao = "";
        }
    }
}
