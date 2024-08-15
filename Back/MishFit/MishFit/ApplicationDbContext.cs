using Microsoft.EntityFrameworkCore;
using MishFit.Entities;

namespace MishFit;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; init; }
    public DbSet<Sleep> Sleeps { get; init; }
    public DbSet<Activity> Activities { get; init; }
    
    public DbSet<MealType> MealTypes { get; init; }
    
    public DbSet<Food> Foods { get; init; }
    
    public DbSet<Nutrition> Nutritions { get; init; }
    
    private readonly IConfiguration _configuration;
    
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("Database"))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}