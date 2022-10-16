using System.Text.Json.Serialization;

namespace EFNewAPI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Weight { get; set; }
    [JsonIgnore]
    public virtual ICollection<Duty>? Duties { get; set; }

}
