namespace VerenaVision.Domain.Entities.Cameras;

public sealed class CameraStatusHistory : EntityBase
{
    public Guid Camera_Id { get; private set; }
    public Camera Camera { get; private set; }
    public CameraStatus Status { get; private set; }

    //EF Core
    private CameraStatusHistory()
    {
    }

    public CameraStatusHistory(Camera camera, CameraStatus status)
    {
        Guard.NotNull(camera);
        Guard.EnumDefined(status);

        Camera_Id = camera.Id;
        Camera = camera;
        Status = camera.Status;
    }
}
