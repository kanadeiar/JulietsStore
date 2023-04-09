namespace JulietsStore.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepo _repo;
    private readonly ICart _cart;

    public OrderController(IOrderRepo repo, ICart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IActionResult Checkout()
    {
        return View(new OrderViewModel());
    }
    [HttpPost]
    public IActionResult Checkout(OrderViewModel model)
    {
        if (!_cart.Lines.Any())
        {
            ModelState.AddModelError("", "Корзина пуста!");
        }
        var order = new Order
        {
            Name = model.Name,
            Line1 = model.Line1,
            Line2 = model.Line2,
            Line3 = model.Line3,
            City = model.City,
            State = model.State,
            Country = model.Country,
            Zip = model.Zip,
            GiftWrap = model.GiftWrap,
        };
        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines.ToArray();
            _repo.SaveOrder(order);
            _cart.Clear();
            return RedirectToAction("Complete", new { Id = order.Id });
        }
        else
        {
            return View(model);
        }
    }
    public IActionResult Complete(int id)
    {
        var order = _repo.Orders.FirstOrDefault(x => x.Id == id);
        var model = new OrderViewModel
        {
            Id = order.Id,
            Name = order.Name,
            Line1 = order.Line1,
            Line2 = order.Line2,
            Line3 = order.Line3,
            City = order.City,
            State = order.State,
            Country = order.Country,
            Zip = order.Zip,
            GiftWrap = order.GiftWrap,
        };
        return View(model);
    }
}