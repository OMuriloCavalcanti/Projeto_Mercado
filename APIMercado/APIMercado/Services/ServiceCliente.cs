using APIMercado.Data;
using APIMercado.Models;
using APIMercado.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIMercado.Services
{
    public class ServiceCliente : ServiceGeneric<Cliente>, ICliente
    {
        private readonly AppDbContext _context;
        public ServiceCliente(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {
            _context = OptionsBuilder;
        }

        public async Task<Cliente> GetPedidoDoCliente(int id)
        {
            return await _context.Cliente
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
