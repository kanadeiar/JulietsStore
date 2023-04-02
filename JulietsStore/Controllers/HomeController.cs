namespace JulietsStore.Controllers;

public class HomeController : Controller
{
    private readonly IProductsRepo _repo;
    public HomeController(IProductsRepo repo)
    {
        _repo = repo;
    }
    public IActionResult Index()
    {
        return View(_repo.Products);
    }
}