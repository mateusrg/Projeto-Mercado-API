using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class FornecedoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Fornecedor>> ListarTodos()
        {
            return Ok(FornecedoresRepository.ListarTodos());
        }

        [HttpGet]
        [Route("id/{idFornecedor}")]
        public ActionResult<Fornecedor?> ConsultarPorId(int idFornecedor)
        {
            var fornecedores = FornecedoresRepository.ConsultarPorId(idFornecedor);
            if (fornecedores == null)
                return BadRequest("Fornecedor não encontrado.");
            return Ok(fornecedores);
        }

        [HttpGet]
        [Route("CNPJ/{CNPJ}")]
        public ActionResult<Fornecedor?> ConsultarPorCNPJ(string CNPJ)
        {
            var fornecedor = FornecedoresRepository.ConsultarPorCNPJ(CNPJ);
            if (fornecedor == null)
                return BadRequest("Fornecedor não encontrado.");
            return Ok(fornecedor);
        }

        [HttpGet]
        [Route("nome/{nome}")]
        public ActionResult<List<Fornecedor>> ConsultarPorNome(string nome)
        {
            return Ok(FornecedoresRepository.ConsultarPorNome(nome));
        }

        [HttpPost]
        public ActionResult<int> Cadastrar(Fornecedor novoFornecedor)
        {
            return Ok(FornecedoresRepository.Cadastrar(novoFornecedor));
        }

        [HttpPut]
        public ActionResult<int> Alterar(Fornecedor fornecedorAlterar)
        {
            if (fornecedorAlterar.IdFornecedor <= 0)
                return BadRequest("O ID do fornecedor deve ser maior do que 0.");
            return Ok(FornecedoresRepository.Alterar(fornecedorAlterar));
        }

        [HttpDelete]
        [Route("{idFornecedor}")]
        public ActionResult<int> ExcluirPorId(int idFornecedor)
        {
            if (idFornecedor <= 0)
                return BadRequest("O ID do fornecedor deve ser maior do que 0.");
            return Ok(FornecedoresRepository.ExcluirPorId(idFornecedor));
        }
    }
}