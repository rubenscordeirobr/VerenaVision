using VerenaVision.Shared.Models.Security;

namespace VerenaVision.Application.Abstractions.Services;

public interface IUserSessionTokenHandler : IApplicationService
{
    string WriteToken(UserSessionClaims userSessionClaims, bool isPersistent);

    UserSessionClaims? ReadToken(string token);
}
