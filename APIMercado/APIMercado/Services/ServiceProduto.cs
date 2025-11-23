using APIMercado.Data;
using APIMercado.Models;
using APIMercado.Services.Interfaces;

namespace APIMercado.Services
{
    public class ServiceProduto : ServiceGeneric<Produto>, IProduto
    {
        public ServiceProduto(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {

        }
        
    }
}
