using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;
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
        public ActionResult<List<VMEstoque>> ConsultarPorTipoEstoque(int idTipoEstoque)
        {
            var estoques = EstoquesRepository.ConsultarPorTipoEstoque(idTipoEstoque);
            return Ok(estoques);
        }

        [HttpGet]
        [Route("descricao/{descricao}")]
        public ActionResult<List<Estoque>> ConsultarPorDescricao(string descricao)
        {
            return Ok(EstoquesRepository.ConsultarPorDescricao(descricao));
        }

        [HttpGet]
        [Route("quantidadeProdutosNoEstoque/{idEstoque}")]
        public ActionResult<List<Estoque>> ConsultarPorQuantProdutosNoEstoque(int idEstoque)
        {
            return Ok(EstoquesRepository.ConsultarPorQuantProdutosNoEstoque(idEstoque));
        }

        [HttpGet]
        [Route("movimentacoesRecentes/{idEstoque}")]
        public ActionResult<List<Estoque>> ListarMovimentacoesRecentes(int idEstoque)
        {
            return Ok(EstoquesRepository.ListarMovimentacoesRecentes(idEstoque));
        }

        [HttpGet]
        [Route("quantidadeProdutoEmTodosEstoques/{codBarras}")]
        public ActionResult<List<Estoque>> ConsultarQuantProdutoEmTodosEstoques(string codBarras)
        {
            return Ok(EstoquesRepository.ConsultarQuantProdutoEmTodosEstoques(codBarras));
        }

        [HttpPost]
        [Route("tipo-estoque")]
        public ActionResult<List<VMEstoque>> ConsultarIdTipoEstoqueEstoqueTipoEstoque(VMEstoque estoque)
        {
            return Ok(EstoquesRepository.ConsultarIdTipoEstoqueEstoqueTipoEstoque(estoque.IdTipoEstoque, estoque.DescricaoEstoque));
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
    }
}
