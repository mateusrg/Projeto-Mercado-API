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

        [HttpGet]
        [Route("id/{idFuncionario}")]
        public ActionResult<Funcionario?> ConsultarPorId(int idFuncionario)
        {
            var funcionario = FuncionariosRepository.ConsultarPorId(idFuncionario);
            if (funcionario == null)
                return BadRequest("Funcionário não encontrado.");
            return Ok(funcionario);
        }

        [HttpGet]
        [Route("nome/{nome}")]
        public ActionResult<List<Funcionario>> ConsultarPorNome(string nome)
        {
            return Ok(FuncionariosRepository.ConsultarPorNome(nome));
        }

        [HttpGet]
        [Route("setor/{setor}")]
        public ActionResult<List<Funcionario>> ConsultarPorSetor(string setor)
        {
            return Ok(FuncionariosRepository.ConsultarPorSetor(setor));
        }

        [HttpGet]
        [Route("email/{email}")]
        public ActionResult<Funcionario> ConsultarPorEmail(string email)
        {
            return Ok(FuncionariosRepository.ConsultarPorEmail(email));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(Funcionario novoFuncionario)
        {
            return Ok(FuncionariosRepository.Cadastrar(novoFuncionario));
        }

        [HttpPut]
        public ActionResult<int> Alterar(Funcionario funcionarioAlterar)
        {
            if (funcionarioAlterar.IdFuncionario <= 0)
            {
                return BadRequest("O ID do funcionário deve ser maior do que 0.");
            }
            return Ok(FuncionariosRepository.Alterar(funcionarioAlterar));
        }

        [HttpDelete]
        [Route("{idFuncionario}")]
        public ActionResult<int> ExcluirPorId(int idFuncionario)
        {
            if (idFuncionario <= 0)
            {
                return BadRequest("O ID do funcionário deve ser maior do que 0.");
            }
            return Ok(FuncionariosRepository.ExcluirPorId(idFuncionario));
        }
    }
}
