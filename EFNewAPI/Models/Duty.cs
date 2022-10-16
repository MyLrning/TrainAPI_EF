namespace EFNewAPI.Models;

public class Duty
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime Deadline { get; set; }
    public virtual Category? Category { get; set; }
    
    public string? Summary { get; set; }

}

public enum Priority
{
    High,
    Medium,
    Low
}

