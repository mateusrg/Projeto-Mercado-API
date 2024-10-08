namespace Projeto_Mercado_API.Models
{
    public class TipoEstoque
    {
        public int IdTipoEstoque { get; set; }
        public string Descricao { get; set; }

        public TipoEstoque()
        {
            IdTipoEstoque = 0;
            Descricao = "";
        }
    }
}