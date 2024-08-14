using Microsoft.EntityFrameworkCore;
using MishFit;
using MishFit.Repositories;
using MishFit.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IMealsTypesRepository, MealsTypesRepository>();
builder.Services.AddScoped<INutritionsRepository, NutritionsRepository>();
builder.Services.AddScoped<IFoodsRepository, FoodsRepository>();
builder.Services.AddScoped<IFoodsService, FoodsService>();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();

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
