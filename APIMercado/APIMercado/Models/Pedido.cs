using System.ComponentModel.DataAnnotations.Schema;

namespace APIMercado.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
