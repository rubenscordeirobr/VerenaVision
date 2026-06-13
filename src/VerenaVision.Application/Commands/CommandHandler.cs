using VerenaVision.Application.Abstractions.Handlers;

namespace VerenaVision.Application.Commands;

public abstract class CommandHandler<TRequest, TResponse>
    : ICommandHandler<TRequest, TResponse>
    where TRequest : ICommandRequest<TResponse>
    where TResponse : IResponse
{
    public Task<Result<TResponse>> RunAsync(
        TRequest command,
        CancellationToken cancellationToken = default)
    {
        return HandleAsync(command, cancellationToken);
    }

    protected abstract Task<Result<TResponse>> HandleAsync(
        TRequest command,
        CancellationToken cancellationToken);
}
