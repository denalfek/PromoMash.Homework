namespace PromoMash.Homework.Web.Server.Dal.SqLite.Entities;

internal sealed class Province()
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int CountryId { get; set; }

    public Country Country { get; set; } = null!;
}
