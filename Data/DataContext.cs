using ConsoleApp.Data.Mappings;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public class DataContext : DbContext
{
    public DbSet<Car>? Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.0.0.1,5434;Database=Auto;User ID=sa;Password=SAPassword@@123;Trusted_Connection=False;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarMap());
    }
}