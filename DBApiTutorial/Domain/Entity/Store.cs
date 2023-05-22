using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; } //= default!;
        public int OwnerId { get; set; }

        public ICollection<Product> Products { get; set; }
            = new List<Product>();

    }
}
