using Microsoft.EntityFrameworkCore;
using DataService.Models;

namespace DataService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; } // Example
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "John Doe", Address = "123 Main St", Age = 20, Dob = new DateTime(2006, 1, 1, 0, 0, 0, DateTimeKind.Utc), Phone = "123-456-7890" },
            new Student { Id = 2, Name = "Jane Smith", Address = "456 Oak Ave", Age = 21, Dob = new DateTime(2005, 5, 15, 0, 0, 0, DateTimeKind.Utc), Phone = "987-654-3210" },
            new Student { Id = 3, Name = "Bob Johnson", Address = "789 Pine Rd", Age = 22, Dob = new DateTime(2004, 10, 20, 0, 0, 0, DateTimeKind.Utc), Phone = "555-123-4567" },
            new Student { Id = 4, Name = "Alice Williams", Address = "321 Elm St", Age = 19, Dob = new DateTime(2007, 3, 10, 0, 0, 0, DateTimeKind.Utc), Phone = "444-555-6666" },
            new Student { Id = 5, Name = "Charlie Brown", Address = "654 Spruce Ln", Age = 23, Dob = new DateTime(2003, 8, 25, 0, 0, 0, DateTimeKind.Utc), Phone = "333-444-5555" }
        );
    }
}