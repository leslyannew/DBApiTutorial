namespace DBApiTutorial.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        //public string CreatedBy { get; set; }
        //public string LastUpdatedBy { get; set; }
        //public DateTimeOffset CreatedOn { get; set; }
        //public DateTimeOffset LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
