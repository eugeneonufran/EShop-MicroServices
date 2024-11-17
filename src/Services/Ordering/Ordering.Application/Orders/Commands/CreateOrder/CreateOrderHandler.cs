namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = CreateNewOrder(command.Order);

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOrderResult(order.Id.Value);
    }

    private Order CreateNewOrder(OrderDTO orderDTO)
    {
        var sa_DTO = orderDTO.ShippingAddress;
        var ba_DTO = orderDTO.BillingAddress;
        var p_DTO = orderDTO.Payment;

        var shippingAddress = Address.Of(sa_DTO.FirstName, sa_DTO.LastName, sa_DTO.EmailAddress, sa_DTO.AddressLine, sa_DTO.Country, sa_DTO.State, sa_DTO.ZipCode);
        var billingAddress = Address.Of(ba_DTO.FirstName, ba_DTO.LastName, ba_DTO.EmailAddress, ba_DTO.AddressLine, ba_DTO.Country, ba_DTO.State, ba_DTO.ZipCode);
        var payment = Payment.Of(p_DTO.CardName, p_DTO.CardNumber, p_DTO.Expiration, p_DTO.Cvv, p_DTO.PaymentMethod);

        var newOrder = Order.Create(
            id: OrderId.Of(Guid.NewGuid()),
            customerId: CustomerId.Of(orderDTO.CustomerId),
            orderName: OrderName.Of(orderDTO.OrderName),
            shippingAddress: shippingAddress,
            billingAddress: billingAddress,
            payment: payment
            );

        return newOrder;
    }
}
