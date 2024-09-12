namespace PokeAPI.Models;

public class BaseEntity
{
    public Guid ID { get; set; }
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? DateUpdated { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }

}