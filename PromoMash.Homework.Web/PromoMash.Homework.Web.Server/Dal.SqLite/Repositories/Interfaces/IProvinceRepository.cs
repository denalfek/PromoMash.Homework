using PromoMash.Homework.Web.Server.Controllers.Models;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

public interface IProvinceRepository
{
    Task<IReadOnlyCollection<ProvinceModel>> Get(int countryId, CancellationToken ct = default);

    Task<bool> Exists(Guid id, CancellationToken ct = default);
}
