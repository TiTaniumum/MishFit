using Microsoft.EntityFrameworkCore;
using MishFit.Entities;
using MishFit.Enums;
using MishFit.Exceptions;
using MishFit.Responses;

namespace MishFit.Repositories;

public class RecommendationsRepository : IRecommendationsRepository
{ 
    private readonly ApplicationDbContext _context;

    public RecommendationsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Recommendation> RandomRecommendation(RecommendationType recommendationType)
    {
        var recommendations = await _context
            .Recommendations
            .Where(r => r.RecommendationType == recommendationType)
            .ToListAsync();

        if (!recommendations.Any())
        {
            throw new ElementNotFoundException($"Recommendations with type {recommendationType} not found.");
        }

        var random = new Random();

        int randomIndex = random.Next(recommendations.Count);

        return recommendations[randomIndex];
    }
}