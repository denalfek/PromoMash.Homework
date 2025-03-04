namespace ClassLibrary1PromoMash.Homework.Dal.SqLite.Entities;

internal sealed class User
{
    public required Guid Id { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}
