using PromoMash.Homework.Dal.SqLite.Models;

namespace PromoMash.Homework.Dal.SqLite.Repositories;

public interface IUserRepository
{
    Task<UserModel?> Get(string email);

    Task Create(UserModel model);
}
