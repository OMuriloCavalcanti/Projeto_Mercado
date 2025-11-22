using APIMercado.Models;

namespace APIMercado.Services.Interfaces
{
    public interface ICliente : IGenerics<Cliente>
    {
        Task<Cliente> GetPedidoDoCliente(int id);
    }
}
