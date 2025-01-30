using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Funcionario>> ListarTodos()
        {
            return Ok(FuncionariosRepository.ListarTodos());
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<Funcionario> Login([FromBody] PaginaLogin request)
        {
            var funcionario = FuncionariosRepository.ConsultarPorEmail(request.Email);

            if (funcionario == null || funcionario.Senha != request.Senha)
            {
                return NotFound("E-mail ou senha inválidos.");
            }

            return Ok(funcionario);
        }
    }
}
