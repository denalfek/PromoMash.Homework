using Microsoft.AspNetCore.Mvc;
using PromoMash.Homework.Web.Server.Controllers.Models;
using System.ComponentModel.DataAnnotations;

namespace PromoMash.Homework.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody][Required] RegistrationForm model)
    {
        await Task.Delay(10);
        return Ok();
    }
}
