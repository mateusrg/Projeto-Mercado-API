using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiposEstoqueController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TipoEstoque>> ListarTodos()
        {
            return Ok(TiposEstoqueRepository.ListarTodos());
        }

        [HttpGet]
        [Route("id/{idTipoEstoque}")]
        public ActionResult<TipoEstoque?> ConsultarPorId(int idTipoEstoque)
        {
            var tipoEstoque = TiposEstoqueRepository.ConsultarPorId(idTipoEstoque);
            if (tipoEstoque == null)
                return BadRequest("Tipo de estoque não encontrado.");
            return Ok(tipoEstoque);
        }

        [HttpGet]
        [Route("descricao/{descricao}")]
        public ActionResult<List<TipoEstoque>> ConsultarPorDescricao(string descricao)
        {
            return Ok(TiposEstoqueRepository.ConsultarPorDescricao(descricao));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(TipoEstoque novoTipoEstoque)
        {
            return Ok(TiposEstoqueRepository.Cadastrar(novoTipoEstoque));
        }

        [HttpPut]
        public ActionResult<int> Alterar(TipoEstoque tipoEstoqueAlterar)
        {
            if (tipoEstoqueAlterar.IdTipoEstoque <= 0)
            {
                return BadRequest("O ID do tipo do estoque deve ser maior do que 0.");
            }
            return Ok(TiposEstoqueRepository.Alterar(tipoEstoqueAlterar));
        }

        [HttpDelete]
        [Route("{idTipoEstoque}")]
        public ActionResult<int> ExcluirPorId(int idTipoEstoque)
        {
            if (idTipoEstoque <= 0)
            {
                return BadRequest("O ID do tipo do estoque deve ser maior do que 0.");
            }
            return Ok(TiposEstoqueRepository.ExcluirPorId(idTipoEstoque));
        }
    }
}
