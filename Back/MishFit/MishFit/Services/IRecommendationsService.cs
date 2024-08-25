using MishFit.Entities;
using MishFit.Enums;

namespace MishFit.Services;

public interface IRecommendationsService
{
    Task<Recommendation> RandomRecommendation(RecommendationType recommendationType);
}