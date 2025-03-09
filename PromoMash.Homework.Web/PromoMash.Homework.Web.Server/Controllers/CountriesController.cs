using Microsoft.AspNetCore.Mvc;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

namespace PromoMash.Homework.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController(
    ICountryRepository repository,
    IHostApplicationLifetime lifetime) : ControllerBase
{
    // PromoMashControllerBase
    private readonly CancellationToken ct = lifetime.ApplicationStopping;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var countries = await repository.Get(ct);
        return Ok(countries);
    }
}
