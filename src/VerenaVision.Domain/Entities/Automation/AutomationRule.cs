using VerenaVision.Domain.Entities.Identities;

namespace VerenaVision.Domain.Entities.Automation;

public sealed class AutomationRule : EntityBase, ITenantOwned, ISoftDeletableEntity, IEventAggregate
{
    private readonly List<IDomainEvent> _events = [];
    public Guid Tenant_Id { get; private set; }
    public Tenant Tenant { get; private set; }
    public Guid Device_Id { get; private set; }
    public Device Device { get; private set; }
    public string Name { get; private set; }
    public AutomationEventType AutomationEventType { get; private set; }
    public bool IsEnabled { get; private set; }
    public DeviceAction DeviceAction { get; private set; }
    public TimeSpan Delay { get; private set; }

    private AutomationRule()
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
