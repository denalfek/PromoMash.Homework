using PromoMash.Homework.Web.Server.Dal.SqLite.Entities;

namespace PromoMash.Homework.Web.Server.Dal.SqLite;

internal static class DbSeeder
{
    public static void Run(PromoMashDbContext context)
    {
        if (!context.Countries.Any())
        {
            var usa = new Country { Name = "United States" };
            var canada = new Country { Name = "Canada" };

            context.Countries.AddRange(usa, canada);
            context.SaveChanges();
            context.Provinces.AddRange(
                new Province { Id = Guid.NewGuid(), Name = "California", CountryId = usa.Id },
                new Province { Id = Guid.NewGuid(), Name = "Texas", CountryId = usa.Id },
                new Province { Id = Guid.NewGuid(), Name = "Ontario", CountryId = canada.Id },
                new Province { Id = Guid.NewGuid(), Name = "Quebec", CountryId = canada.Id }
            );
            context.SaveChanges();
        }
    }
}
