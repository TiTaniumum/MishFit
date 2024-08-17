using MishFit.Enums;

namespace MishFit.Responses;

public record RecommendationResponse(
    Guid Id,
    string Title,
    string Recommendation,
    RecommendationType RecommendationType
);