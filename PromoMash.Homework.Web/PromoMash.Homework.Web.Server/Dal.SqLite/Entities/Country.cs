namespace PromoMash.Homework.Web.Server.Dal.SqLite.Entities;

internal sealed class Country()
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Province> Provinces { get; set; } = [];
}
