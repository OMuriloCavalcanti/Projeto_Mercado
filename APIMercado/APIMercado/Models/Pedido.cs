using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIMercado.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        public int ProdutoId { get; set; }
        
        [JsonIgnore]
        public Produto? Produto { get; set; }
        // Depois fazer uma List<Produto> 
    }
}
