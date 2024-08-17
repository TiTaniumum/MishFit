using MishFit.Entities;
using MishFit.Enums;
using MishFit.Exceptions;
using MishFit.Repositories;

namespace MishFit.Services;

public class RecommendationsService : IRecommendationsService
{
    private readonly IRecommendationsRepository _repository;

    public RecommendationsService(IRecommendationsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Recommendation> RandomRecommendation(RecommendationType recommendationType)
    {
        if (!Enum.IsDefined(typeof(RecommendationType), recommendationType))
        {
            throw new InvalidIncomingParameterException($"No such recommendation type. {recommendationType}");
        }

        return await _repository.RandomRecommendation(recommendationType);
    }
}