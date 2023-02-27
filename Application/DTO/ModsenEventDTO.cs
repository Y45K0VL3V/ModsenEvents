namespace Application.DTO
{
    public class ModsenEventDTO
    {
        public Guid Id { get; private init; } = Guid.Empty;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Speaker { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public string Place { get; set; }
    }
}
