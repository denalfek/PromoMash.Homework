using PromoMash.Homework.Web.Server.Controllers.Models;

namespace PromoMash.Homework.Web.Server.Services.Interfaces;

public interface IRegistrationService
{
    Task<ServiceResultModel> Create(UserDomain model, CancellationToken ct = default);
}
