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

    }
}
