using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories;

internal class CountryRepository(PromoMashDbContext dbContext) : ICountryRepository
{
    public async Task<bool> Exists(int id, CancellationToken ct = default)
    {
        var result = await dbContext
            .Countries
            .AnyAsync(x => x.Id == id, ct);

        return result;
    }

    public async Task<IReadOnlyCollection<CountryModel>> Get(CancellationToken ct = default)
    {
        var countries = await dbContext
            .Countries
            .AsNoTracking()
            .Select(x => new CountryModel { Id = x.Id, Name = x.Name })
            .ToArrayAsync(ct);

        return countries;
    }
}
