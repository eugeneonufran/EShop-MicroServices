namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username should not be empty");
        }
    }
        public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
        {
            public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
            {
                //TODO: delete
                return new DeleteBasketResult(false);
            }
        }
}
