using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Models.View_Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacoesEstoqueController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MovimentacaoEstoque>> ListarTodos()
        {
            return Ok(MovimentacoesEstoqueRepository.ListarTodos());
        }

        [HttpGet]
        [Route("view")]
        public ActionResult<List<MovimentacaoEstoque>> ListarTodosView()
        {
            return Ok(MovimentacoesEstoqueRepository.ListarTodosView());
        }


        [HttpGet]
        [Route("id/{idMovimentacaoEstoque}")]
        public ActionResult<MovimentacaoEstoque?> ConsultarPorId(int idMovimentacaoEstoque)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorId(idMovimentacaoEstoque);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("estoque/{idEstoque}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorEstoque(int idEstoque)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorEstoque(idEstoque);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("tipoMovimentacaoEstoque/{idTipoMovimentacaoEstoque}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorTipoMovimentacaoEstoque(int idTipoMovimentacaoEstoque)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorTipoMovimentacaoEstoque(idTipoMovimentacaoEstoque);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("funcionarioSolicitador/{idFuncionarioSolicitador}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorFuncionarioSolicitador(int idFuncionarioSolicitador)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorFuncionarioSolicitador(idFuncionarioSolicitador);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("funcionarioAutenticador/{idFuncionarioAutenticador}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorFuncionarioAutenticador(int idFuncionarioAutenticador)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorFuncionarioAutenticador(idFuncionarioAutenticador);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("produto/{idProduto}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorProduto(int idProduto)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorProduto(idProduto);
            if (movimentacaoEstoque == null)
                return BadRequest("Movimentação de estoque não encontrada.");
            return Ok(movimentacaoEstoque);
        }

        [HttpGet]
        [Route("data/{dataInicio}/{dataFim}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorData(string dataInicio, string dataFim)
        {
            return Ok(MovimentacoesEstoqueRepository.ConsultarPorData(dataInicio, dataFim));
        }

        [HttpPost]
        [Route("venderProduto")]
        public ActionResult<string> Vender(VMVenda vendaEstoque)
        {
            if (vendaEstoque.IdEstoque <= 0)
            {
                return BadRequest("O ID do estoque deve ser maior do que 0.");
            }

            var retorno = MovimentacoesEstoqueRepository.Vender(vendaEstoque);
            if (retorno == 0)
            {
                return BadRequest($"Não há {vendaEstoque.Quantidade} unidades deste produto no estoque.");
            }
            return Ok("Venda realizada com sucesso.");
        }

        [HttpPost]
        [Route("movimentarProdutoEntreEstoques")]
        public ActionResult<string> FazerMovimentacao(VMMovimentacoesEstoque movimentacaoEstoque)
        {
            if (movimentacaoEstoque.idEstoqueOrigem <= 0)
            {
                return BadRequest("O ID do estoque de origem deve ser maior do que 0.");
            }

            if (movimentacaoEstoque.idEstoqueDestino <= 0)
            {
                return BadRequest("O ID do estoque de destino deve ser maior do que 0.");
            }

            var retorno = MovimentacoesEstoqueRepository.FazerMovimentacao(movimentacaoEstoque);
            if (retorno == 0)
            {
                return BadRequest($"Não há {movimentacaoEstoque.quantidade} unidades deste produto no estoque de origem informado.");
            }
            return Ok("Movimentação realizada com sucesso.");
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(MovimentacaoEstoque novaMovimentacaoEstoque)
        {
            return Ok(MovimentacoesEstoqueRepository.Cadastrar(novaMovimentacaoEstoque));
        }

        [HttpPut]
        public ActionResult<int> Alterar(MovimentacaoEstoque movimentacaoEstoqueAlterar)
        {
            if (movimentacaoEstoqueAlterar.IdMovimentacaoEstoque <= 0)
            {
                return BadRequest("O ID da movimentação do estoque deve ser maior do que 0.");
            }
            return Ok(MovimentacoesEstoqueRepository.Alterar(movimentacaoEstoqueAlterar));
        }

        [HttpDelete]
        [Route("{idMovimentacaoEstoque}")]
        public ActionResult<int> ExcluirPorId(int idMovimentacaoEstoque)
        {
            if (idMovimentacaoEstoque <= 0)
            {
                return BadRequest("O ID da movimentação do estoque deve ser maior do que 0.");
            }
            return Ok(FuncionariosRepository.ExcluirPorId(idMovimentacaoEstoque));
        }

        [HttpGet]
        [Route("estoqueCompleto/{idEstoque}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorEstoqueCompleto(int idEstoque)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorEstoqueCompleto(idEstoque);
            if (movimentacaoEstoque == null)
                return BadRequest("estoque não encontrado.");
            return Ok(movimentacaoEstoque);
        }
        [HttpGet]
        [Route("produtoCompleto/{idProduto}")]
        public ActionResult<List<MovimentacaoEstoque>> ConsultarPorProdutoCompleto(int idProduto)
        {
            var movimentacaoEstoque = MovimentacoesEstoqueRepository.ConsultarPorProdutoCompleto(idProduto);
            if (movimentacaoEstoque == null)
                return BadRequest("produto não encontrado.");
            return Ok(movimentacaoEstoque);
        }
    }

}