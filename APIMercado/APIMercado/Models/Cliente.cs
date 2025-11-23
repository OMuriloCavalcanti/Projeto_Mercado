using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIMercado.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        [JsonIgnore]
        public List<Pedido>? Pedidos { get; set; }

    }
}
