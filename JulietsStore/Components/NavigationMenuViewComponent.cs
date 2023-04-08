namespace JulietsStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly IProductsRepo _repo;
    
    public NavigationMenuViewComponent(IProductsRepo repo)
    {
        _repo = repo;
    }
    public IViewComponentResult Invoke(string? category)
    {
        var products = _repo.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
        ViewBag.SelectedCategory = category;
        return View(products);
    }
}