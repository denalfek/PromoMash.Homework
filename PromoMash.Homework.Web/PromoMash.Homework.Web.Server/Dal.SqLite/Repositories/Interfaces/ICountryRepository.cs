using PromoMash.Homework.Web.Server.Controllers.Models;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

public interface ICountryRepository
{
    Task<IReadOnlyCollection<CountryModel>> Get(CancellationToken ct = default);
}
