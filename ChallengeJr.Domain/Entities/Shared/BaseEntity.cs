namespace ChallengeJr.Domain.Entities.Shared;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public string GetCreatedAt() => CreatedAt.ToString("yyyy-MM-dd");
    public string? GetUpdatedAt() => UpdatedAt?.ToString("yyyy-MM-dd");
}
