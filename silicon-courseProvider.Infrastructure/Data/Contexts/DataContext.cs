using Microsoft.EntityFrameworkCore;
using silicon_courseProvider.Infrastructure.Data.Entities;

namespace silicon_courseProvider.Infrastructure.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEntity>().ToContainer("Courses");
        modelBuilder.Entity<CourseEntity>().HasPartitionKey(c => c.Category);
        modelBuilder.Entity<CourseEntity>().OwnsOne(c => c.Prices);
        modelBuilder.Entity<CourseEntity>().OwnsMany(c => c.Authors);
    }
}
