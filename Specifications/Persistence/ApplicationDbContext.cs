using Microsoft.EntityFrameworkCore;
using Specifications.Models;

namespace Specifications.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<DigitalContentItem> DigitalItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<DigitalContentItem>()
            .Property(i => i.Type)
            .HasConversion<string>();

        modelBuilder
            .Entity<DigitalContentItem>()
            .Property(i => i.Format)
            .HasConversion<string>();
    }
}
