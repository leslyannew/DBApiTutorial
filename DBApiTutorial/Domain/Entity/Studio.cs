using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Developer>? Developers { get; set; } = new List<Developer>();
        public ICollection<Game>? Games { get; set; } = new List<Game>();

        public Studio(string name)
        {
            Name = name;
        }
    }
}
