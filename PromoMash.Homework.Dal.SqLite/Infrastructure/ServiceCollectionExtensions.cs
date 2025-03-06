using Microsoft.Extensions.DependencyInjection;
using PromoMash.Homework.Dal.SqLite.Repositories;

namespace PromoMash.Homework.Dal.SqLite.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddPromoMashDbContext(this IServiceCollection services)
    {
        services.AddDbContext<PromoMashDbContext>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
