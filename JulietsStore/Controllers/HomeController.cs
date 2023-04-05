namespace JulietsStore.Controllers;

public class HomeController : Controller
{
    private readonly IProductsRepo _repo;
    private int pageSize = 4;
    public HomeController(IProductsRepo repo)
    {
        _repo = repo;
    }
    public IActionResult Index(string? category, int productPage = 1)
    {
        var products = _repo.Products
            .Where(x => category == null || x.Category == category)
            .OrderBy(x => x.Id);
        var model = new ProductsListViewModel
        {
            Products = products
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize).ToArray(),
            PagingInfo = new PagingInfoViewModel {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalCountItems = products.Count(),
            },
            CurrentCategory = category,
        };
        return View(model);
    }
}