namespace JulietsStore.Domain.ViewModels;

public class LoginViewModel
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Password { get; set; }
    public string ReturnUrl { get; set; } = "/";
}

