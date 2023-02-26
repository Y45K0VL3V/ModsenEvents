namespace Application.DTO
{
    public class ModsenEventDTO
    {
        public Guid Id { get; private init; } = Guid.Empty;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Speaker { get; set; }
        public DateOnly DateUtc { get; set; }
        public TimeOnly TimeUtc { get; set; }
        public string Place { get; set; }
    }
}
