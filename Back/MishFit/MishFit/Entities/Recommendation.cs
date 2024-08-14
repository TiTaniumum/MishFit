namespace MishFit.Entities;

public class Recommendation
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;
    
    public DateTime MentionDate { get; set; }
    
    private Recommendation() {}
}