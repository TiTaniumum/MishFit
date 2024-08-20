using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MishFit.Enums;

namespace MishFit.Entities;


public class Recommendation
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [MaxLength(100)] public String Title { get; set; } = string.Empty;

    public String Content { get; set; } = string.Empty;
    public RecommendationType RecommendationType { get; set; }
    
    public DateTime AddDateTime { get; set; }

    public DateTime DeleteDateTime { get; set; }
}