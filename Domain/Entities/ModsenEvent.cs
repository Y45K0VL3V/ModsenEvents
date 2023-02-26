using Domain.Primitives;

namespace Domain.Entities
{
    public class ModsenEvent : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Speaker { get; set; }
        public DateOnly DateUtc { get; set; }
        public TimeOnly TimeUtc { get; set; }
        public string Place { get; set; }

        //// TODO : check links types
        //public string Creator { get; }
        public DateTime CreationDateUtc { get; } = DateTime.UtcNow;
    }
}
