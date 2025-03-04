using PromoMash.Homework.Dal.SqLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace PromoMash.Homework.Dal.SqLite;

internal sealed class PromoMashDbContext(DbContextOptions<PromoMashDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users { get; set; }

    private const string ConnectionString = "Data Source=app.db";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder
            .Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(ConnectionString);
}
