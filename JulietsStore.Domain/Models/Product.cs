namespace JulietsStore.Domain.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Пожалуйста, введите название товара")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Пожалуйста, укажите категорию товара")]
    public string Category { get; set; } = string.Empty;
    [Required, Range(double.Epsilon, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное число")]
    [Column(TypeName="decimal(8, 2)")]
    public decimal Price { get; set; }
}