using VerenaVision.Domain.Entities.Identities;

namespace VerenaVision.Domain.Entities.Automation;

public sealed class Device : EntityBase, ITenantOwned, ISoftDeletableEntity, IEventAggregate
{
    private readonly List<IDomainEvent> _events = [];
    public Guid Tenant_Id { get; private set; }
    public Tenant Tenant { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ControllerId { get; private set; }
    public int PinNumber { get; private set; }
    public DeviceStatus Status { get; private set; }

    // EF Core constructor
    private Device()
    {
    }
     
    #region ISoftDeletableEntity, IDomainEventAggregate
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedSession_Id { get; private set; }
    IReadOnlyList<IDomainEvent> IEventAggregate.DomainEvents
        => _events;
   
    #endregion
}
