using System.ComponentModel.DataAnnotations.Schema;

namespace APIMercado.Models
{
    [Table("Produto")]
    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

    }
}
