using System.Text.Json.Serialization;

namespace CleanArch.Domain.Entities;

public abstract class Entity
{
    [JsonPropertyOrder(-100)]
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.Now;
    public DateTime? DeletedAt { get; protected set; } = null;
}
