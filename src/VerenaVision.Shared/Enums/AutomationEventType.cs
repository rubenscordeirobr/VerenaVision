namespace VerenaVision.Shared.Enums;
 
public enum AutomationEventType
{
    PersonDetected,
    VehicleDetected,
    CarDetected,
    TruckDetected,
    MotorcycleDetected,
    BicycleDetected,

    UnknownObjectDetected,

    LicensePlateRecognized,
    UnauthorizedVehicleDetected,

    CameraOffline,
    CameraOnline,

    MotionDetected,

    DetectionStarted,
    DetectionStopped
}
