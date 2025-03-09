namespace PromoMash.Homework.Web.Server.Controllers.Models;

public class RegistrationForm
{
    public required string Email { get; set; }

    public required string Password { get; set; }

    public int CountryId { get; set; }
    public Guid ProvinceId { get; set; }
}
