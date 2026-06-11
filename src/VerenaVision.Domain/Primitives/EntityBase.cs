namespace VerenaVision.Domain.Primitives;

public abstract class EntityBase : IEntityBase
{
    public long Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime LastUpdatedAt { get; protected set; }

    public override string ToString()
    {
        if (Id == 0)
        {
            return $"{GetType().Name}: Id=New";
        }
        return $"{GetType().Name}: Id={Id}, CreatedAt={CreatedAt}, LastUpdatedAt={LastUpdatedAt}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj is null)
            return false;

        if (obj is not EntityBase other)
            return false;

        return obj.GetType() != GetType()
            && Id > 0
            && Id == other.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }
}
