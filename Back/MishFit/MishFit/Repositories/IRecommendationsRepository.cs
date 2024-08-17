using MishFit.Entities;
using MishFit.Enums;

namespace MishFit.Repositories;

public interface IRecommendationsRepository
{
    Task<Recommendation> RandomRecommendation(RecommendationType recommendationType);
}