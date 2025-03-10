using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Web.Server.Dal.SqLite.Entities;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;
using PromoMash.Homework.Web.Server.Services;

namespace PromoMash.Homework.Web.Server.Dal.SqLite.Repositories;

internal sealed class UserRepository(PromoMashDbContext dbContext) : IUserRepository
{
    public async Task Create(UserDomain model, CancellationToken ct = default)
    {
        var entity = new User()
        {
            Id = Guid.NewGuid(),
            Email = model.Email,
            Password = model.Password,
            CountryId = model.CountryId,
            ProvinceId = model.ProvinceId
        };

        await dbContext.Users.AddAsync(entity, ct);
        await dbContext.SaveChangesAsync(ct);
    }

    public async Task<bool> Exists(string email, CancellationToken ct = default)
    {
        var result = await dbContext
            .Users
            .AnyAsync(x => x.Email == email, ct);
        return result;
    }

    public async Task<UserResponse?> Get(string email, CancellationToken ct = default)
    {
        var entity = await dbContext
            .Users
            .Include(x => x.Country)
            .Include(x => x.Province)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email, ct);

        if (entity == null) return null;

        var model = new UserResponse(entity.Email, entity.Country.Name, entity.Province.Name);

        return model;
    }
}
