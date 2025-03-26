using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiposMovimentacaoEstoqueController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TipoMovimentacaoEstoque>> ListarTodos()
        {
            return Ok(TiposMovimentacaoEstoqueRepository.ListarTodos());
        }

        [HttpGet]
        [Route("id/{idTipoMovimentacaoEstoque}")]
        public ActionResult<TipoMovimentacaoEstoque?> ConsultarPorId(int idTipoMovimentacaoEstoque)
        {
            var tipoMovimentacaoEstoque = TiposMovimentacaoEstoqueRepository.ConsultarPorId(idTipoMovimentacaoEstoque);
            if (tipoMovimentacaoEstoque == null)
                return BadRequest("Tipo de movimentação de estoque não encontrado.");
            return Ok(tipoMovimentacaoEstoque);
        }

        [HttpGet]
        [Route("movimentacoes/{idTipoMovimentacaoEstoque}")]
        public ActionResult<List<TipoMovimentacaoEstoque>> ListarMovimentacoesPorTipo(int idTipoMovimentacaoEstoque)
        {
            return Ok(TiposMovimentacaoEstoqueRepository.ListarMovimentacoesPorTipo(idTipoMovimentacaoEstoque));
        }

        [HttpPost]
        [Route("descricao")]
        public ActionResult<List<TipoMovimentacaoEstoque>> ConsultarPorDescricao(PesquisaPadrao pesquisa)
        {
            return Ok(TiposMovimentacaoEstoqueRepository.ConsultarPorDescricao(pesquisa.Query));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(TipoMovimentacaoEstoque novoTipoMovimentacaoEstoque)
        {
            return Ok(TiposMovimentacaoEstoqueRepository.Cadastrar(novoTipoMovimentacaoEstoque));
        }

        [HttpPut]
        public ActionResult<int> Alterar(TipoMovimentacaoEstoque tipoMovimentacaoEstoqueAlterar)
        {
            if (tipoMovimentacaoEstoqueAlterar.IdTipoMovimentacaoEstoque <= 0)
            {
                return BadRequest("O ID do tipo da movimentação do estoque deve ser maior do que 0.");
            }
            return Ok(TiposMovimentacaoEstoqueRepository.Alterar(tipoMovimentacaoEstoqueAlterar));
        }

        [HttpDelete]
        [Route("{idTipoMovimentacaoEstoque}")]
        public ActionResult<int> ExcluirPorId(int idTipoMovimentacaoEstoque)
        {
            if (idTipoMovimentacaoEstoque <= 0)
            {
                return BadRequest("O ID do tipo da movimentação do estoque deve ser maior do que 0.");
            }
            return Ok(TiposMovimentacaoEstoqueRepository.ExcluirPorId(idTipoMovimentacaoEstoque));
        }
    }
}