using APIMercado.Data;
using APIMercado.Models;
using APIMercado.Services.Interfaces;

namespace APIMercado.Services
{
    public class ServiceCliente : ServiceGeneric<Cliente>, ICliente
    {
        public ServiceCliente(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {
        }
    }
}
