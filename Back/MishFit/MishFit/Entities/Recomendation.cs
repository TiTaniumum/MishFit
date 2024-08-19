using System.ComponentModel.DataAnnotations;
using MishFit.Enums;

namespace MishFit.Entities;

public class Recommendation
{   
    public Guid Id { get; set; }

    [MaxLength(100)] public String Title { get; set; } = string.Empty;

    public String Content { get; set; } = string.Empty;
    
    public Guid RecommendationTypeId { get; set; }
    
    public RecommendationType RecommendationType { get; set; }
    
    public DateTime AddDateTime { get; set; }

    public DateTime DeleteDateTime { get; set; }
}