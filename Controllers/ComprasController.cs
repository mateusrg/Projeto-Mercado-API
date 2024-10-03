using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        [HttpGet]
        [Route("id/{idCompra}")]
        public ActionResult<Compra?> ConsultarPorId(int idCompra)
        {
            var compra = ComprasRepository.ConsultarPorId(idCompra);
            if (compra == null)
                return BadRequest("Compra não encontrada.");
            return Ok(compra);
        }

        [HttpGet]
        [Route("idFornecedor/{idFornecedor}")]
        public ActionResult<List<Compra>> ConsultarPorIdFornecedor(int idFornecedor)
        {
            return Ok(ComprasRepository.ConsultarPorIdFornecedor(idFornecedor));
        }

        [HttpGet]
        [Route("idProduto/{idProduto}")]
        public ActionResult<List<Compra>> ConsultarPorIdProduto(int idProduto)
        {
            return Ok(ComprasRepository.ConsultarPorIdProduto(idProduto));
        }

        [HttpGet]
        [Route("data/{data}")]
        public ActionResult<List<Compra>> ConsultarPorData(string dataInicio, string dataFim)
        {
            return Ok(ComprasRepository.ConsultarPorData(dataInicio, dataFim));
        }

        [HttpGet]
        [Route("quantidade/{quantidade}")]
        public ActionResult<List<Compra>> ConsultarPorQuantidade(int quantidade)
        {
            return Ok(ComprasRepository.ConsultarPorQuantidade(quantidade));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(Compra novaCompra)
        {
            return Ok(ComprasRepository.Cadastrar(novaCompra));
        }

        [HttpPut]
        public ActionResult<int> Alterar(Compra compraAlterar)
        {
            if (compraAlterar.IdCompra <= 0)
                return BadRequest("O ID da compra deve ser maior do que 0.");
            return Ok(ComprasRepository.Alterar(compraAlterar));
        }

        [HttpDelete]
        [Route("{idCompra}")]
        public ActionResult<int> ExcluirPorId(int idCompra)
        {
            if (idCompra <= 0)
                return BadRequest("O ID da compra deve ser maior do que 0.");
            return Ok(FornecedoresRepository.ExcluirPorId(idCompra));
        }
    }
}
