
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommand received");
            var productToUpdate = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException();

            productToUpdate.Name = command.Name;
            productToUpdate.Category = command.Category;
            productToUpdate.Price = command.Price;
            productToUpdate.ImageFile = command.ImageFile;
            session.Update(productToUpdate);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
