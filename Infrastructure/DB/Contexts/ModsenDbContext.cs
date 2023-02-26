using Domain.DbCustom.Comparers;
using Domain.DbCustom.Converters;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Contexts
{
    public class ModsenDbContext : DbContext
    {

        public ModsenDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModsenEvent>(builder =>
            {
                builder.Property(x => x.DateUtc)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();

                builder.Property(x => x.TimeUtc)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });
        }

        public DbSet<ModsenEvent> Events { get; set; }
    }
}
