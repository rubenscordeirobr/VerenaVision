using VerenaVision.Domain.Entities.Detections;
using VerenaVision.Domain.Entities.Identities;

namespace VerenaVision.Domain.Entities.Cameras;

 
public sealed class Camera : EntityBase, ITenantOwned, ISoftDeletableEntity, IEventAggregate
{
    private readonly List<IDomainEvent> _events = [];
    private readonly List<Detection> _detections = [];
    private readonly List<CameraStatusHistory> _statusHistories = [];

    public Guid Tenant_Id { get; private set; }
    public Tenant Tenant { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Url { get; private set; }
    public string RTSPUrl { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string LocalIP { get; private set; }
    public string Model { get; private set; }
  
    public CameraStatus Status { get; private set; }
    public IReadOnlyList<Detection> Detections 
        => _detections;
    public IReadOnlyList<CameraStatusHistory> StatusHistories 
        => _statusHistories;

    public bool IsActive
      => this.Status == CameraStatus.Online;

    // EF Core constructor
    private Camera()
    {
    }
  
    public CameraStatusHistory AddStatusHistory(CameraStatus status)
    {
        var statusHistory = new CameraStatusHistory(this, status);
        _statusHistories.Add(statusHistory);
        return statusHistory;
    }

    #region ISoftDeletableEntity, IDomainEventAggregate

    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedSession_Id { get; private set; }

    IReadOnlyList<IDomainEvent> IEventAggregate.DomainEvents
        => _events;

    #endregion
}
