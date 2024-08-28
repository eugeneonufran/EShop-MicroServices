
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest(int? PageNumber, int? PageSize);
    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var results = await sender.Send(query);
                var response = results.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("GetProducts");
            
        }
    }
}
