namespace VerenaVision.Shared.Models.Security;

public record UserSessionClaims(
    Guid Session_Id,
    string Name,
    string Email,
    string PhoneNumber,
    bool IsPersistent,
    UserRole UserRole,
    UserType UserType,
    DateTime? Expiration = null
);
