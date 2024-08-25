using MishFit.Enums;

namespace MishFit.Responses;

public record RecommendationResponse(
    long Id,
    string Title,
    string Recommendation,
    RecommendationType RecommendationType
);