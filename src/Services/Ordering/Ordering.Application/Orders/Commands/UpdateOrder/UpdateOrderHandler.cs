using Ordering.Application.DTOs;
using Ordering.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    internal class UpdateOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.Order.Id);
            var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);

            if (order == null)
            {
                throw new OrderNotFoundException(command.Order.Id);
            }

            UpdateOrder(order, command.Order);

            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateOrderResult(true);
        }

        private void UpdateOrder(Order order, OrderDTO newOrder)
        {
            var sa_DTO = newOrder.ShippingAddress;
            var ba_DTO = newOrder.BillingAddress;
            var p_DTO = newOrder.Payment;

            var shippingAddress = Address.Of(sa_DTO.FirstName, sa_DTO.LastName, sa_DTO.EmailAddress, sa_DTO.AddressLine, sa_DTO.Country, sa_DTO.State, sa_DTO.ZipCode);
            var billingAddress = Address.Of(ba_DTO.FirstName, ba_DTO.LastName, ba_DTO.EmailAddress, ba_DTO.AddressLine, ba_DTO.Country, ba_DTO.State, ba_DTO.ZipCode);
            var payment = Payment.Of(p_DTO.CardName, p_DTO.CardNumber, p_DTO.Expiration, p_DTO.Cvv, p_DTO.PaymentMethod);

            order.Update(
                orderName: OrderName.Of(newOrder.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: payment,
                status: newOrder.Status
                );

        }
    }
}
