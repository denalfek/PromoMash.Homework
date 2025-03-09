using PromoMash.Homework.Web.Server.Dal.SqLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace PromoMash.Homework.Web.Server.Dal.SqLite;

internal sealed class PromoMashDbContext(DbContextOptions<PromoMashDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Province> Provinces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder
            .Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId);

        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Province)
            .WithMany()
            .HasForeignKey(u => u.ProvinceId);

        modelBuilder
            .Entity<Country>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Country>()
           .HasMany(c => c.Provinces)
           .WithOne(p => p.Country)
           .HasForeignKey(p => p.CountryId);

        modelBuilder
            .Entity<Province>()
            .HasKey(x => x.Id);
    }
}
