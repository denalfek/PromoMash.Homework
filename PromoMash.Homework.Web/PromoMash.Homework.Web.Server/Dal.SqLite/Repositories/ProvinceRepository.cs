using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories;

internal class ProvinceRepository(PromoMashDbContext dbContext) : IProvinceRepository
{
    public async Task<bool> Exists(Guid id, CancellationToken ct = default)
    {
        var result = await dbContext
            .Provinces
            .AnyAsync(x => x.Id == id, ct);

        return result;
    }

    public async Task<IReadOnlyCollection<ProvinceModel>> Get(int countryId, CancellationToken ct = default)
    {
        var provinces = await dbContext
            .Provinces
            .AsNoTracking()
            .Where(x => x.CountryId == countryId)
            .Select(x => new ProvinceModel { Id = x.Id, Name = x.Name })
            .ToArrayAsync(ct);

        return provinces;
    }
}
