using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition.DTO
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
            = new List<Product>();
        public int NumberOfProducts
        {
            get
            {
                return Products.Count;
            }
        }
    }
}
