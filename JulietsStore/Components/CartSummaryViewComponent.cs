namespace JulietsStore.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly ICart _cart;

    public CartSummaryViewComponent(ICart cart)
    {
        _cart = cart;
    }

    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}