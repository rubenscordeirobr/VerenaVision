using VerenaVision.Application.Models.Communication;

namespace VerenaVision.Application.Abstractions.Services;

public interface IEmailSender : IApplicationService
{
    Task<bool> SendEmailAsync(Email email);
}
