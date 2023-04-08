

namespace JulietsStore.Controllers;

public class CartController : Controller
{
    private readonly IProductsRepo _repo;
    private readonly ICart _cart;

    public CartController(IProductsRepo repo, ICart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IActionResult Index(string? returnUrl)
    {
        var model = new CartViewModel
        {
            Cart = _cart,
            ReturnUrl = returnUrl ?? "/",
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Add(int id, string? returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            _cart.AddItem(product, 1);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl = returnUrl });
    }
    [HttpPost]
    public IActionResult Remove(int id, string? returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            _cart.RemoveLine(product);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl = returnUrl });
    }
    [HttpPost]
    public IActionResult Clear(string? returnUrl)
    {
        _cart.Clear();
        return RedirectToAction("Index", "Cart", new { returnUrl = returnUrl });
    }
}