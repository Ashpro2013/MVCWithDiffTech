using Microsoft.EntityFrameworkCore;
using DataService.Models;

namespace DataService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; } // Example
    public DbSet<Department> Departments { get; set; }
}