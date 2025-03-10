using Microsoft.AspNetCore.Mvc;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PromoMash.Homework.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvincesController(IProvinceRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery][Required] int countryId)
    {
        var provinces = await repository.Get(countryId);
        return Ok(provinces);
    }
}
