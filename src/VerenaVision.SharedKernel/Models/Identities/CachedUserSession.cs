using System.Text.Json.Serialization;
using VerenaVision.Shared.Interfaces.Identities;

namespace VerenaVision.Shared.Models.Identities;

public class CachedUserSession : IUserSession
{
    public Guid Id { get; }
    public string ApplicationName { get; }
    public string IpAddress { get; }
    public string UserAgent { get; }
    public bool IsActive { get; }
    public bool IsPersistent { get; }
    public DateTime LastActivity { get; }
    public DateTime StartedAt { get; }
    public DateTime? TerminatedAt { get; }
    public AuthenticationType AuthenticationType { get; }
    public SessionTerminationReason? TerminationReason { get; }
    public UserRole UserRole { get; }
    public UserType UserType { get; }
    public Guid User_Id { get; }
    public Guid? Tenant_Id { get; }
    public GeoLocation? GeoLocation { get; }

    [JsonConstructor]
    private CachedUserSession(
         Guid id,
         string applicationName,
         string ipAddress,
         string userAgent,
         bool isActive,
         bool isPersistent,
         DateTime lastActivity,
         DateTime startedAt,
         DateTime? terminatedAt,
         AuthenticationType authenticationType,
         SessionTerminationReason? terminationReason,
         UserRole userRole,
         UserType userType,
         Guid user_Id,
         Guid? tenant_Id,
         GeoLocation? geoLocation
     )
    {
        Id = id;
        ApplicationName = applicationName;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        IsActive = isActive;
        IsPersistent = isPersistent;
        LastActivity = lastActivity;
        StartedAt = startedAt;
        TerminatedAt = terminatedAt;
        AuthenticationType = authenticationType;
        TerminationReason = terminationReason;
        UserRole = userRole;
        UserType = userType;
        User_Id = user_Id;
        Tenant_Id = tenant_Id;
        GeoLocation = geoLocation;
    }

    public static CachedUserSession Create(IUserSession session)
    {
        Guard.NotNull(session);

        return new CachedUserSession(
            id: session.Id,
            applicationName: session.ApplicationName,
            ipAddress: session.IpAddress,
            userAgent: session.UserAgent,
            isActive: session.IsActive,
            isPersistent: session.IsPersistent,
            lastActivity: session.LastActivity,
            startedAt: session.StartedAt,
            terminatedAt: session.TerminatedAt,
            authenticationType: session.AuthenticationType,
            terminationReason: session.TerminationReason,
            userRole: session.UserRole,
            userType: session.UserType,
            user_Id: session.User_Id,
            tenant_Id: session.Tenant_Id,
            geoLocation: session.GeoLocation
        );
    }

    internal static CachedUserSession Create(
         Guid id,
         string applicationName,
         string ipAddress,
         string userAgent,
         bool isActive,
         bool isPersistent,
         DateTime lastActivity,
         DateTime startedAt,
         DateTime? terminatedAt,
         AuthenticationType authenticationType,
         SessionTerminationReason? terminationReason,
         UserRole userRole,
         UserType userType,
         Guid user_Id,
         Guid? tenant_Id,
         GeoLocation? geoLocation)
    {
        return new CachedUserSession(
            id,
            applicationName,
            ipAddress,
            userAgent,
            isActive,
            isPersistent,
            lastActivity,
            startedAt,
            terminatedAt,
            authenticationType,
            terminationReason,
            userRole,
            userType,
            user_Id,
            tenant_Id,
            geoLocation
        );
    }
}
