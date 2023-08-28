namespace APICompraV1.Services
{
    public class CompraService : ICompraService     
    {

        private readonly DataContext _dbContext;

        public CompraService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Compra>> GetComprasAsync()
        {
            return await _dbContext.Compras.Include(c =>c.Cliente).Include(c => c.Produto).ToListAsync();
        }

        public async Task<Compra?> GetCompraByIdAsync(int id)
        {
            return await _dbContext.Compras.Include(c => c.Cliente).Include(c => c.Produto)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task CreateCompraAsync(Compra compra)
        {
            _dbContext.Compras.Add(compra);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
