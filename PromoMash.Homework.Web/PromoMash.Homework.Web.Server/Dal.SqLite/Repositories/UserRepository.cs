using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Web.Server.Dal.SqLite.Entities;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories;

internal sealed class UserRepository(PromoMashDbContext dbContext) : IUserRepository
{
    public async Task Create(RegistrationForm model)
    {
        var entity = new User()
        { Id = Guid.NewGuid(), Email = model.Email, Password = model.Password };

        await dbContext.Users.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<RegistrationForm?> Get(string email)
    {
        var entity = await dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);

        if (entity == null) return null;

        var model = new RegistrationForm
        { Email = entity.Email, Password = entity.Password };

        return model;
    }
}
