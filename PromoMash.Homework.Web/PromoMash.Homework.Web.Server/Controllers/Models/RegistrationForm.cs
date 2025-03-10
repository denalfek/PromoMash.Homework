﻿namespace PromoMash.Homework.Web.Server.Controllers.Models;

public class RegistrationForm
{
    public required string Email { get; set; }

    public required string Password { get; set; }

    public int Country { get; set; }
    public Guid Province { get; set; }
}
