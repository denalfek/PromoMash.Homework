using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Dal.SqLite.Entities;
using PromoMash.Homework.Dal.SqLite.Models;

namespace PromoMash.Homework.Dal.SqLite.Repositories;

internal sealed class UserRepository(PromoMashDbContext dbContext) : IUserRepository
{
    public async Task Create(UserModel model)
    {
        var entity = new User()
        { Id = Guid.NewGuid(), Email = model.Email, Password = model.Password };

        await dbContext.Users.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<UserModel?> Get(string email)
    {
        var entity = await dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);

        if (entity == null) return null;

        var model = new UserModel
        { Email = entity.Email, Password = entity.Password };

        return model;
    }
}
