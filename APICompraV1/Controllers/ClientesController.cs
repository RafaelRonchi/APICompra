using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICompraV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        [HttpGet("{id}/compras")]
        public async Task<ActionResult<Cliente>> GetComprasDoCliente(int id)
        {
            var compras = await _clienteService.GetComprasDoCliente(id);
            return Ok(compras);
        }
        [HttpGet("{id}/produtos")]
        public async Task<ActionResult<Cliente>> GetProdutosCompradosDoCliente(int id)
        {
            var compras = await _clienteService.GetProdutosCompradosDoCliente(id);
            return Ok(compras);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(Cliente cliente)
        {
            await _clienteService.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _clienteService.UpdateClienteAsync(id, cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
