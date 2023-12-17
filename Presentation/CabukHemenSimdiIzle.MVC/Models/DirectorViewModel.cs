namespace CabukHemenSimdiIzle.MVC.Models
{
    public class DirectorViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
