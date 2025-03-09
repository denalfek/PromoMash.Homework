using PromoMash.Homework.Web.Server.Controllers.Models;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

public interface IUserRepository
{
    Task<RegistrationForm?> Get(string email);

    Task Create(RegistrationForm model);
}
