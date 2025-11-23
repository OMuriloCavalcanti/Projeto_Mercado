using APIMercado.Data;
using APIMercado.Models;
using APIMercado.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIMercado.Services
{
    public class ServicePedido : ServiceGeneric<Pedido>, IPedido
    {
        private readonly AppDbContext _context;

        public ServicePedido(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {
            _context = OptionsBuilder;
        }

    }
}
