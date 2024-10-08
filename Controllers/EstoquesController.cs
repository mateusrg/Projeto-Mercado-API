using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoquesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Estoque>> ListarTodos()
        {
            return Ok(EstoquesRepository.ListarTodos());
        }

        [HttpGet]
        [Route("id/{idEstoque}")]
        public ActionResult<Estoque?> ConsultarPorId(int idEstoque)
        {
            var estoque = EstoquesRepository.ConsultarPorId(idEstoque);
            if (estoque == null)
                return BadRequest("Estoque não encontrado.");
            return Ok(estoque);
        }

        [HttpGet]
        [Route("tipoEstoque/{idTipoEstoque}")]
        public ActionResult<Estoque?> ConsultarPorTipoEstoque(int idTipoEstoque)
        {
            var estoque = EstoquesRepository.ConsultarPorTipoEstoque(idTipoEstoque);
            if (estoque == null)
                return BadRequest("Estoque não encontrado.");
            return Ok(estoque);
        }

        [HttpGet]
        [Route("descricao/{descricao}")]
        public ActionResult<List<Estoque>> ConsultarPorDescricao(string descricao)
        {
            return Ok(EstoquesRepository.ConsultarPorDescricao(descricao));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(Estoque novoEstoque)
        {
            return Ok(EstoquesRepository.Cadastrar(novoEstoque));
        }

        [HttpPut]
        public ActionResult<int> Alterar(Estoque estoqueAlterar)
        {
            if (estoqueAlterar.IdEstoque <= 0)
            {
                return BadRequest("O ID do estoque deve ser maior do que 0.");
            }
            return Ok(EstoquesRepository.Alterar(estoqueAlterar));
        }

        [HttpDelete]
        [Route("{idEstoque}")]
        public ActionResult<int> ExcluirPorId(int idEstoque)
        {
            if (idEstoque <= 0)
            {
                return BadRequest("O ID do estoque deve ser maior do que 0.");
            }
            return Ok(EstoquesRepository.ExcluirPorId(idEstoque));
        }
    }
}
