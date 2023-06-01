using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.GamePublisher
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Role { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; } //= default!;

        public ICollection<Game>? Games { get; set; } = new List<Game>();

        public Developer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
