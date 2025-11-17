using ChallengeJr.Domain.Entities;
using ChallengeJr.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ChallengeJr.Infra.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ProductConfig());
    }
}
