using VerenaVision.Application.Abstractions.Handlers;

namespace VerenaVision.Application.Abstractions.Events;

public interface IPreProcessorHandler<in TEvent> :IApplicationHandler
    where TEvent : IDomainEvent
{
    Task PreProcessAsync(
        IDomainEventData<TEvent> eventData,
        CancellationToken cancellationToken = default);

    Task IApplicationHandler.HandleAsync(object handlerObject)
    {
        return PreProcessAsync((IDomainEventData<TEvent>)handlerObject);
    }
}
