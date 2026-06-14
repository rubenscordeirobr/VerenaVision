using VerenaVision.Shared.Enums;

namespace VerenaVision.Shared.Interfaces.Identities;

public interface ITenant
{
    string Name { get; }
    string Email { get; }
    Country Country { get; }
    Language Language { get; }
    TenantState TenantState { get; }
    TenantStatus TenantStatus { get; }
    TenantType TenantType { get; }
    VerificationState EmailVerificationState { get; }
    VerificationState PhoneNumberVerificationState { get; }
    PhoneNumber PhoneNumber { get; }
    FiscalCode FiscalCode { get; }
    TimeZoneOffset TimeZoneOffset { get; }
}
