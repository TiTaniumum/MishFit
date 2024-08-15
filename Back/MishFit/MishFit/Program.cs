using Microsoft.EntityFrameworkCore;
using MishFit;
using MishFit.Repositories;
using MishFit.Security;
using MishFit.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>();


services.AddScoped<IUsersRepository, UsersRepository>();
services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
services.AddScoped<ISleepRepository, SleepRepository>();

services.AddScoped<IUsersService, UsersService>();
services.AddScoped<IActivitiesService, ActivitiesService>();
services.AddScoped<ISleepsService, SleepsService>();

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();



services.AddScoped<IMealsTypesRepository, MealsTypesRepository>();
services.AddScoped<INutritionsRepository, NutritionsRepository>();
services.AddScoped<IFoodsRepository, FoodsRepository>();
services.AddScoped<IFoodsService, FoodsService>();

services.AddHealthChecks();

services.AddControllers();

builder.Logging.AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.Run();
