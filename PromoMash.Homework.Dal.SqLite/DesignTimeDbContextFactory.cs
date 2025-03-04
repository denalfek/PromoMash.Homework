using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PromoMash.Homework.Dal.SqLite;

internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PromoMashDbContext>
{
    public PromoMashDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PromoMashDbContext>();
        return new PromoMashDbContext(optionsBuilder.Options);
    }
}
