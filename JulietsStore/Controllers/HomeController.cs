namespace JulietsStore.Controllers;

public class HomeController : Controller
{
    private readonly IProductsRepo _repo;
    private int pageSize = 4;
    public HomeController(IProductsRepo repo)
    {
        _repo = repo;
    }
    public IActionResult Index(int productPage = 1)
    {
        var model = new ProductsListViewModel
        {
            Products = _repo.Products
                .OrderBy(x => x.Id)
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize),
            PagingInfo = new PagingInfoViewModel {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalCountItems = _repo.Products.Count(),
            }
        };
        return View(model);
    }
}