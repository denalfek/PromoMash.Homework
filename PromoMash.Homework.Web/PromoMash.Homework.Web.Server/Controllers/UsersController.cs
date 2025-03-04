using Microsoft.AspNetCore.Mvc;
using PromoMash.Homework.Dal.SqLite.Models;
using PromoMash.Homework.Dal.SqLite.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PromoMash.Homework.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery][Required] string email)
    {
        var model = await userRepository.Get(email);

        if (model == null) return NoContent();
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody][Required] UserModel model)
    {
        await userRepository.Create(model);
        return Ok();
    }
}
