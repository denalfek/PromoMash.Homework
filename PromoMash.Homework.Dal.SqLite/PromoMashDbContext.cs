using PromoMash.Homework.Dal.SqLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace PromoMash.Homework.Dal.SqLite;

internal sealed class PromoMashDbContext(DbContextOptions<PromoMashDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users { get; set; }
}
