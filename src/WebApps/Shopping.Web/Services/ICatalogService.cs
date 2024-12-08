namespace Shopping.Web.Services;

public interface ICatalogService
{
    Task<GetProductsResponse> GetProductsAsync(int? pageNumber = 1, int? pageSize = 10);
    Task<GetProductByIdResponse> GetProductAsync(Guid id);
    Task<GetProductByCategoryResponse> GetProductByCategoryAsync(string category);
}
