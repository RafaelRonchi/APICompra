using APICompraV1.Models;

namespace APICompraV1.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<IEnumerable<Compra>> GetComprasDoCliente(int idCliente); 
        Task<IEnumerable<Produto>> GetProdutosCompradosDoCliente(int idCliente);
        Task CreateClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(int id, Cliente cliente);
        Task DeleteClienteAsync(int id);

    }
}
