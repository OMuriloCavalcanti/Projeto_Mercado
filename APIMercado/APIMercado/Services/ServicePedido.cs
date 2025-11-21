using APIMercado.Data;
using APIMercado.Models;
using APIMercado.Services.Interfaces;

namespace APIMercado.Services
{
    public class ServicePedido : ServiceGeneric<Pedido>, IPedido
    {
        public ServicePedido(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {
        }
    }
}
