namespace JulietsStore.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Введите имя")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Введите первую строку адреса")]
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    [Required(ErrorMessage = "Введите название города")]
    public string? City { get; set; }
    [Required(ErrorMessage = "Введите название области")]
    public string? State { get; set; }
    [Required(ErrorMessage = "Введите название страны")]
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public bool GiftWrap { get; set; }
    public bool IsShipped { get; set; }
}

