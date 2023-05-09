namespace JulietsStore.Controllers;

public class WorkersController : Controller
{
    private readonly IEnumerable<Worker> _workers = EmployeesData.GetWorkers;

    public WorkersController()
    {
        
    }

    public IActionResult Index()
    {
        return View(_workers);
    }

    public IActionResult Details(int id)
    {
        var worker = _workers.FirstOrDefault(_ => _.Id == id);
        return View(worker);
    }
}