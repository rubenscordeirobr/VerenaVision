using VerenaVision.Application.Models.Security;

namespace VerenaVision.Application.Abstractions.Security;

public interface IAuthenticationAttemptLimiterService
{
    Task IncrementFailedAttemptsAsync(
        string ipAddress, 
        CancellationToken cancellationToken = default);

    Task<MaxAuthenticationResult> MaxAuthenticationReachedAsync(
            string ipAddress, 
            CancellationToken cancellationToken = default);
}
