namespace PromoMash.Homework.Web.Server.Controllers.Models;

public class UserResponse(
    string email, string countryName, string provinceName)
{
    public string Email { get; set; } = email;

    public string CountryName { get; set; } = countryName;

    public string ProvinceName { get; set; } = provinceName;
}
