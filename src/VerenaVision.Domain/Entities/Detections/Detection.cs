using VerenaVision.Domain.Entities.Cameras;

namespace VerenaVision.Domain.Entities.Detections;

public sealed class Detection : EntityBase, ISoftDeletableEntity, IEventAggregate
{
    private readonly List<IDomainEvent> _events = [];
    private readonly List<Snapshot> _snapshots= [];
    public int? TrackingId { get; private set; }
    public Guid Camera_Id { get; private set; }
    public Camera Camera { get; private set; }
    public long FrameNumber { get; private set; }
    public string Label { get; init; }
    public YoloClass YoloClass { get; init; }
    public double Confidence { get; private set; }
    public DetectionType DetectionType { get; set; }
    public BoundingBox BoundingBox { get; private set; }

    public IReadOnlyList<Snapshot> Snapshots
        => _snapshots;
    private Detection()
    {
    }

    internal Detection(
        Camera camera,
        long frameNumber,
        YoloClass yoloClass,
        string label,
        double confidence,
        DetectionType detectionType,
        BoundingBox boundingBox,
        int? trackingId = null)
    {
        Guard.NotNull(camera);
        Guard.NotNullOrWhiteSpace(label);
        Guard.NotNull(boundingBox);
        
        Camera = camera;
        Camera_Id = camera.Id;
        FrameNumber = frameNumber;
        YoloClass = yoloClass;
        Label = label;
        Confidence = confidence;
        DetectionType = detectionType;
        BoundingBox = boundingBox;
        TrackingId = trackingId;
    }

    #region ISoftDeletableEntity, IDomainEventAggregate
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedSession_Id { get; private set; }
    IReadOnlyList<IDomainEvent> IEventAggregate.DomainEvents
        => _events;
    #endregion
}
