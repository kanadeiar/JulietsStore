using JulietsStore.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace JulietsStore.Tests.Components;

public class NavigationMenuViewComponentTests
{
    [Fact]
    public void Invoke_CanSelectCategories_ShouldOk()
    {
        var mock = new Mock<IProductsRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] {
            new Product { Id = 1, Name = "Name1", Category = "Apples" },
            new Product { Id = 2, Name = "Name2", Category = "Apples" },
            new Product { Id = 3, Name = "Name3", Category = "Mini" },
            new Product { Id = 4, Name = "Name4", Category = "Violet" },
        }).AsQueryable());
        var target = new NavigationMenuViewComponent(mock.Object);
        
        var results = ((IEnumerable<string>)(target.Invoke(null) as ViewViewComponentResult)!.ViewData!.Model!)!.ToArray();

        Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Mini", "Violet" }, results));
    }
    [Fact]
    public void Indicates_Selected_Category()
    {
        var categoryToSelect = "Apples";
        var mock = new Mock<IProductsRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] {
            new Product { Id = 1, Name = "Name1", Category = "Apples" },
            new Product { Id = 2, Name = "Name2", Category = "Apples" },
            new Product { Id = 3, Name = "Name3", Category = "Mini" },
            new Product { Id = 4, Name = "Name4", Category = "Violet" },
        }).AsQueryable());
        var target = new NavigationMenuViewComponent(mock.Object);

        var result = (string)(target.Invoke(categoryToSelect) as ViewViewComponentResult)!.ViewData["SelectedCategory"];

        Assert.Equal(categoryToSelect, result);
    }
}