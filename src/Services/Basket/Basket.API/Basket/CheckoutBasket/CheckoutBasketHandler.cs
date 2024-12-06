namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDTO BasketCheckoutDTO) : ICommand<CheckoutBasketResult>;

public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDTO).NotNull().WithMessage("BasketCheckoutDTO cannot be null");
        RuleFor(x => x.BasketCheckoutDTO.UserName).NotEmpty().WithMessage("UserName cannot be empty");
    }
}
public class CheckoutBasketHandler
    (IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var userName = command.BasketCheckoutDTO.UserName;

        var basket = await repository.GetBasketAsync(userName, cancellationToken);
        if (basket == null)
        {
            return new CheckoutBasketResult(false);
        }

        var eventMessage = command.BasketCheckoutDTO.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;
        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasketAsync(userName, cancellationToken);

        return new CheckoutBasketResult(true);
    }
}