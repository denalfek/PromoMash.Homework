using Microsoft.AspNetCore.Identity;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;
using PromoMash.Homework.Web.Server.Services.Interfaces;

namespace PromoMash.Homework.Web.Server.Services;

internal sealed class RegistrationService(
    IPasswordHasher<UserDomain> passwordHasher,
    IUserRepository userRepository,
    ICountryRepository countryRepository,
    IProvinceRepository provinceRepository,
    ILogger<RegistrationService> logger) : IRegistrationService
{
    public async Task<ServiceResultModel> Create(
        UserDomain model,
        CancellationToken ct = default)
    {
        var result = new ServiceResultModel();
        if (!await countryRepository.Exists(model.CountryId, ct))
        {
            var err = $"Country {model.CountryId} doesn't exists";

            logger.LogError(err);
            result.Errors.Add(err);
            return result;
        }

        if (!await provinceRepository.Exists(model.ProvinceId, ct))
        {
            var err = $"Province {model.ProvinceId} doesn't exists";

            logger.LogError(err);
            result.Errors.Add(err);
            return result;
        }

        if (await userRepository.Exists(model.Email, ct))
        {
            var err = $"Email {model.Email} already exists";

            logger.LogError(err);
            result.Errors.Add(err);
            return result;
        }

        model.Password = passwordHasher
            .HashPassword(model, model.Password);

        await userRepository.Create(model, ct);
        return result;
    }
}
