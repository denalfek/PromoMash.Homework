using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Services;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserResponse?> Get(string email, CancellationToken ct = default);

    Task<bool> Exists(string email, CancellationToken ct = default);

    Task Create(UserDomain model, CancellationToken ct = default);
}
