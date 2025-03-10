using Microsoft.AspNetCore.Mvc;
using PromoMash.Homework.Web.Server.Controllers.Models;
using PromoMash.Homework.Web.Server.Services;
using PromoMash.Homework.Web.Server.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PromoMash.Homework.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController(
    IRegistrationService service,
    IHostApplicationLifetime lifetime) : ControllerBase
{
    private readonly CancellationToken _ct = lifetime.ApplicationStopping;

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody][Required] RegistrationForm request)
    {
        var model = new UserDomain
        {
            Email = request.Email,
            Password = request.Password,
            CountryId = request.Country,
            ProvinceId = request.Province
        };

        var result = await service.Create(model, _ct);
        return result.Success ? Ok() : BadRequest();
    }
}
