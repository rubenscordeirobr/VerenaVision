namespace VerenaVision.Domain.Entities.Detections;

public sealed class Snapshot : EntityBase
{
    public Guid Detection_Id { get; private set; }
    public Detection Detection { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    // EF Core constructor
    private Snapshot()
    {

    }

    internal Snapshot(
        Detection detection,
        int width, 
        int height)
    {
        Guard.NotNull(detection);
        Guard.Positive(width);
        Guard.Positive(height);

        Detection = detection;
        Detection_Id = detection.Id;
        Width = width;
        Height = height;
    }
}
