using Microsoft.AspNetCore.Mvc;
using Projeto_Mercado_API.Models;
using Projeto_Mercado_API.Repositories;

namespace Projeto_Mercado_API.Controllers
{
    public class TiposMovimentacaoEstoque : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TipoEstoque>> ListarTodos()
        {
            return Ok(TiposMovimentacaoEstoqueRepository.ListarTodos());
        }
    }
}
