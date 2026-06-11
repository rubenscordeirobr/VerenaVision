namespace VerenaVision.Shared.Abstractions;

public interface IEntityBase
{
    long Id { get; }
    DateTime CreatedAt { get; }
    DateTime LastUpdatedAt { get; }
}