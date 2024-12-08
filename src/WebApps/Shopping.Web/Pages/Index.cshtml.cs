namespace Shopping.Web.Pages
{
    public class IndexModel(ICatalogService catalogService, ILogger<IndexModel> logger) : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<ProductModel> ProductList { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            logger.LogInformation("Index page visited");

            var result = await catalogService.GetProducts();
            //var result = await catalogService.GetProducts(2,3);
            ProductList = result.Products;

            return Page();
        }
    }
}
