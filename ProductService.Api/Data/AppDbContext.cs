using Microsoft.EntityFrameworkCore;
using ProductService.Api.Models;

namespace ProductService.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("T_Product");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.Stock).IsRequired();
        });
    }
}