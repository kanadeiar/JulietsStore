namespace JulietsStore.Models;

public class Worker : ModelBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime EmploymentDate { get; set; }
    public int CountClildren { get; set; }
}

