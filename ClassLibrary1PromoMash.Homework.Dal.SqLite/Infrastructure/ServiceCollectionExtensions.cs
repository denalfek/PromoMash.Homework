using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassLibrary1PromoMash.Homework.Dal.SqLite.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PromoMashDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqLiteConnectionString")));
    }
}
