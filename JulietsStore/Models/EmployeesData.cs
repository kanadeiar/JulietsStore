namespace JulietsStore.Models;

public class EmployeesData
{
    public static List<Worker> GetWorkers => Enumerable.Range(1, 10).Select(p => new Worker
    {
        Id = p,
        FirstName = $"Иван_{p}",
        LastName = $"Иванов_{p + 1}",
        Patronymic = $"Иванович_{p + 2}",
        Age = p + 20,
        Birthday = new DateTime(1980 + p, 1, 1),
        EmploymentDate = DateTime.Now.AddYears(-p).AddMonths(p),
        CountClildren = p,
    }).ToList();
}