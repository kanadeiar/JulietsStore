namespace JulietsStore.Infra.Data;

public class OrdersRepo : IOrderRepo
{
    private readonly DbContext _context;
    public OrdersRepo(JulietsStoreDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Order> Orders => _context.Set<Order>()
        .Include(x => x.Lines)
        .ThenInclude(x => x.Product);

    public void SaveOrder(Order order)
    {
        _context.AttachRange(order.Lines.Select(x => x.Product));
        if (order.Id == 0)
        {
            _context.Set<Order>().Add(order);
        }
        _context.SaveChanges();
    }
}