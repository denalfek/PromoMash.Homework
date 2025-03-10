using Microsoft.EntityFrameworkCore;
using PromoMash.Homework.Web.Server.Dal.SqLite;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PromoMashDbContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IProvinceRepository, ProvinceRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI
// at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("CorsPolicy",
        policy => policy
            .WithOrigins("https://localhost:51211")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PromoMashDbContext>();    
    DbSeeder.Run(context);
}

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
