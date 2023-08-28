using APICompraV1.Models;

namespace APICompraV1.Services
{
    public class ClienteService : IClienteService
    {
        private readonly DataContext _dbContext;

        public ClienteService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }
        public async Task<IEnumerable<Compra>> GetComprasDoCliente(int idCliente)
        {
            return await _dbContext.Compras
                .Where(c => c.ClienteId == idCliente)
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .ToListAsync();
        }
        public async Task<IEnumerable<Produto>> GetProdutosCompradosDoCliente(int idCliente)
        {
            return await _dbContext.Compras
                 .Where(c => c.ClienteId == idCliente)
                 .Select(c => c.Produto)
                 .Distinct()
                 .ToListAsync();            
        }
        public async Task CreateClienteAsync(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return;
            }

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
