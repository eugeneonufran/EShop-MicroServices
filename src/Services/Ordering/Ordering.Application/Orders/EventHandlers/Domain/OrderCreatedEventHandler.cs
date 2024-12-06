namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedEventHandler> logger) 
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {

        logger.LogInformation("Domain event handled: {DomainEvent}", domainEvent.GetType().Name);

        var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDTO();

        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}