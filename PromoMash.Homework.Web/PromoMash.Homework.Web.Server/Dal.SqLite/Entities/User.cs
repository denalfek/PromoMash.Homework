namespace PromoMash.Homework.Web.Server.Dal.SqLite.Entities;

internal sealed class User
{
    public required Guid Id { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public Guid ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
}
