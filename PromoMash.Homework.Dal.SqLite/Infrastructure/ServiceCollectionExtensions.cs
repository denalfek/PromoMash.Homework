using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoMash.Homework.Dal.SqLite.Repositories;

namespace PromoMash.Homework.Dal.SqLite.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddPromoMashDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PromoMashDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqLiteConnectionString")));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
