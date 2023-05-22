using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; } //= default!;
        public int StoreId { get; set; }
    }
}
