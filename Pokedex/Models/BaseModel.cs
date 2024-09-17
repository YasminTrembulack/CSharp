using System;

namespace PokeAPI.Models;

public class BaseModel 
{
    public Guid Id { get; set; }
    public required string CreatedAt { get; set; }
    public required string UpdatedAt { get; set; }
    public required string DeletedAt { get; set; }
}