namespace JulietsStore.Domain.ViewModels;

public class PagingInfoViewModel
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalCountItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalCountItems / ItemsPerPage);
}