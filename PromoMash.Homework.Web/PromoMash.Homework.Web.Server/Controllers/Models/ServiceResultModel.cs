namespace PromoMash.Homework.Web.Server.Controllers.Models;

public class ServiceResultModel
{
    public bool Success => Errors.Count == 0;

    public List<string> Errors { get; set; } = [];
}
