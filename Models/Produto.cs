namespace Projeto_Mercado_API.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string CodBarras { get; set; }
        public string Descricao { get; set; }

        public Produto ()
        {
            IdProduto = 0;
            CodBarras = "";
            Descricao = "";
        }
    }
}
