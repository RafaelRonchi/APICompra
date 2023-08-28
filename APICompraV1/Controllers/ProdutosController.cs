using APICompraV1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICompraV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetPropdutos()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduto(Produto produto)
        {
            await _produtoService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProdutoById), new {id = produto.Id },produto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduto(int id,Produto produto)
        {
            if(id != produto.Id) return BadRequest();
            await _produtoService.UpdateProdutoAsync(id, produto);  
            return Ok("Produto atualizado com sucesso");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            await _produtoService.DeleteProdutoAsync(id);
            return Ok("Produto excluído com sucesso");
        }
    }
}
