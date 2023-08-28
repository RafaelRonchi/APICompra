using APICompraV1.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APICompraV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public ComprasController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            var compras = await _compraService.GetComprasAsync();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _compraService.GetCompraByIdAsync(id);
            return Ok(compra);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCompra(CompraDTO compra)
        {
            var compraModel = new Compra
            {
                Id = compra.Id,
                DataCompra = compra.DataCompra,
                ClienteId = compra.ClienteId,
                ProdutoId = compra.ProdutoId
            };

            await _compraService.CreateCompraAsync(compraModel);
            return CreatedAtAction(nameof(GetCompra), new {id =  compra.Id}, compra);
        }


    }
}
