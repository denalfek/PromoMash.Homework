using PromoMash.Homework.Dal.SqLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace PromoMash.Homework.Dal.SqLite;

internal sealed class PromoMashDbContext(DbContextOptions<PromoMashDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users { get; set; }

    private string ConnectionString =
        "Data Source=C:\\Users\\sokol\\source\\repos\\PromoMash.Homework\\PromoMash.Homework.Dal.SqLite\\bin\\Debug\\net8.0\\app.db";
        //"Data Source=PromoMash.Homework.Dal.SqLite\\bin\\Debug\\net8.0\\app.db";
        //"Data Source=app.db";

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
