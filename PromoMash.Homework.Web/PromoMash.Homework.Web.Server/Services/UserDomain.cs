namespace PromoMash.Homework.Web.Server.Services;

public sealed class UserDomain
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int CountryId { get; set; }
    public Guid ProvinceId { get; set; }
}
