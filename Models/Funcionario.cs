namespace Projeto_Mercado_API.Models
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Funcionario()
        {
            IdFuncionario = 0;
            Nome = "";
            Setor = "";
            Email = "";
            Senha = "";
        }
    }

    public class PaginaLogin
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
