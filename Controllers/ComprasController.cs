using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        [HttpGet]
        [Route("informacoes")]
        public ActionResult<List<InformacoesCompra>> ListarTodosView()
        {
            return Ok(ComprasRepository.ListarTodosView());
        }

        [HttpPost]
        [Route("informacoes")]
        public ActionResult<int> CadastrarView(InformacoesCompra novaCompra)
        {
            return Ok(ComprasRepository.CadastrarView(novaCompra));
        }

        [HttpPut]
        [Route("informacoes")]
        public ActionResult<int> AlterarView(InformacoesCompra compraAlterar)
        {
            if (compraAlterar.IdCompra <= 0)
                return BadRequest("O ID da compra deve ser maior do que 0.");
            return Ok(ComprasRepository.AlterarView(compraAlterar));
        }

        [HttpGet]
        public ActionResult<List<Compra>> ListarTodos()
        {
            return Ok(ComprasRepository.ListarTodos());
        }

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
            var compra = ComprasRepository.ConsultarPorIdFornecedor(idFornecedor);
            if (compra == null)
                return BadRequest("Compra não encontrada.");
            return Ok(compra);
        }

        [HttpGet]
        [Route("idProduto/{idProduto}")]
        public ActionResult<List<Compra>> ConsultarPorIdProduto(int idProduto)
        {
            var compra = ComprasRepository.ConsultarPorIdFornecedor(idProduto);
            if (compra == null)
                return BadRequest("Compra não encontrada.");
            return Ok(compra);
        }

        [HttpGet]
        [Route("data/{dataInicio}/{dataFim}")]
        public ActionResult<List<Compra>> ConsultarPorData(string dataInicio, string dataFim)
        {
            return Ok(ComprasRepository.ConsultarPorData(dataInicio, dataFim));
        }

        [HttpPost]
        [Route("tudo")]
        public ActionResult<List<Compra>> ConsultarPorTudo(FiltroParaCompra compra)
        {
            var resultado = ComprasRepository.ConsultarPorTudo(compra);
            return Ok(resultado);
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

        [HttpPost]
        [Route("Compra")]
        public ActionResult<int> Comprar(SolicitacaoCompra compra)
        {
            Compra novaCompra = new Compra()
            {
                IdFornecedor = compra.IdFornecedor,
                IdProduto = compra.IdProduto,
                Data = compra.Data,
                Quantidade = compra.Quantidade
            };
            MovimentacaoEstoque novaMovimentacaoEstoque = new MovimentacaoEstoque()
            {
                IdProduto = compra.IdProduto,
                IdEstoque = 1,
                IdTipoMovimentacaoEstoque = 1,
                IdFuncionarioAutenticador = compra.IdFuncionarioAutenticador,
                IdFuncionarioSolicitador = compra.IdFuncionarioSolicitador,
                DataHora = compra.Data,
                Quantidade = compra.Quantidade
            };
            var resultado = (ComprasRepository.Cadastrar(novaCompra), MovimentacoesEstoqueRepository.Cadastrar(novaMovimentacaoEstoque));
            return Ok("Compra cadastrada com sucesso!");
        }
        
        [HttpGet]
        [Route("ConsultarCompraCompleta/{IdCompraCompleta}")]
        public ActionResult<CompraCompleta> ConsultarCompraCompleta(int IdCompraCompleta)
        {
            var resultado = ComprasRepository.ConsultarCompraCompleta(IdCompraCompleta);
            if (resultado == null) { return BadRequest("Compra não encontrada.");}
                
            return Ok(resultado);
        }

    }
}
