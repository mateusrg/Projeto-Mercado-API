using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Produto>> ListarTodos()
        {
            return Ok(ProdutosRepository.ListarTodos());
        }

        [HttpGet]
        [Route("tudo/{texto}")]
        public ActionResult<List<Produto>> ConsultarPorTudo(string texto)
        {
            return Ok(ProdutosRepository.ConsultarPorTudo(texto));
        }

        [HttpGet]
        [Route("id/{idProduto}")]
        public ActionResult<Produto?> ConsultarPorId(int idProduto)
        {
            var produto = ProdutosRepository.ConsultarPorId(idProduto);
            if (produto == null)
                return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        [HttpGet]
        [Route("codBarras/{codBarras}")]
        public ActionResult<Produto?> ConsultarPorCodBarras(string codBarras)
        {
            var produto = ProdutosRepository.ConsultarPorCodBarras(codBarras);
            if (produto == null)
                return BadRequest("Produto não encontrado.");
            return Ok(produto);
        }

        [HttpGet]
        [Route("descricao/{descricao}")]
        public ActionResult<List<Produto>> ConsultarPorDescricao(string descricao)
        {
            return Ok(ProdutosRepository.ConsultarPorDescricao(descricao));
        }

        [HttpGet]
        [Route("descricaoECodBarras/{texto}")]
        public ActionResult<List<Produto>> ConsultarPorDescricaoECodBarras(string texto)
        {
            return Ok(ProdutosRepository.ConsultarPorDescricaoECodBarras(texto));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(Produto novoProduto)
        {
            return Ok(ProdutosRepository.Cadastrar(novoProduto));
        }

        [HttpPut]
        public ActionResult<int> Alterar(Produto produtoAlterar)
        {
            if (produtoAlterar.IdProduto <= 0)
            {
                return BadRequest("O ID do produto deve ser maior do que 0.");
            }
            return Ok(ProdutosRepository.Alterar(produtoAlterar));
        }

        [HttpDelete]
        [Route("{idProduto}")]
        public ActionResult<int> ExcluirPorId(int idProduto)
        {
            if (idProduto <= 0)
            {
                return BadRequest("O ID do produto deve ser maior do que 0.");
            }
            return Ok(ProdutosRepository.ExcluirPorId(idProduto));
        }
    }
}