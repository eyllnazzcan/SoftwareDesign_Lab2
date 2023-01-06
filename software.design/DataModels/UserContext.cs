using Microsoft.EntityFrameworkCore;
using Software.Design.Models;

namespace Software.Design.DataModels;

public class CapitalContext : DbContext
{
    public CapitalContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Capital> Capitals => Set<Capital>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Capital>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Capital>().ToTable("capitals", schema: "capital");
    }
}