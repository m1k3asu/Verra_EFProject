namespace EFTestProject.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public int ProjectId { get; set; }
    }
}
