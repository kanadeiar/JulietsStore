namespace JulietsStore.Domain.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "����������, ������� �������� ������")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "����������, ������� �������� ������")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "����������, ������� ��������� ������")]
    public string Category { get; set; } = string.Empty;
    [Required, Range(double.Epsilon, double.MaxValue, ErrorMessage = "����������, ������� ������������� �����")]
    [Column(TypeName="decimal(8, 2)")]
    public decimal Price { get; set; }
}