
namespace Catalog.API.Products.GetProducts
{
    //public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var results = await sender.Send(new GetProductsQuery());
                var response = results.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("GetProducts");
            
        }
    }
}
