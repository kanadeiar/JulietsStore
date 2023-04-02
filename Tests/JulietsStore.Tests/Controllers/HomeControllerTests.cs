namespace JulietsStore.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Index_CanUseRepo_ShoulOk()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
        };
        var mock = new Mock<IProductsRepo>();
        mock.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mock.Object);

        var model = (controller.Index() as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.Equal(2, products.Length);
        Assert.Equal(expecteds[0].Name, products[0].Name);
        Assert.Equal(expecteds[1].Name, products[1].Name);
    }
    [Fact]
    public void Index_CanPaginate_ShouldOk()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
            new Product { Id = 3, Name = "Имя3" },
            new Product { Id = 4, Name = "Имя4" },
            new Product { Id = 5, Name = "Имя5" },
            new Product { Id = 6, Name = "Имя6" },
        };
        var mock = new Mock<IProductsRepo>();
        mock.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mock.Object);

        var model = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.Equal(2, products.Length);
        Assert.Equal(expecteds[4].Name, products[0].Name);
        Assert.Equal(expecteds[5].Name, products[1].Name);
    }
    [Fact]
    public void Index_SendPaginationViewModel_ShouldOk()
    {
        var mock = new Mock<IProductsRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] { 
            new Product { Id = 1, Name = "Good1" },
            new Product { Id = 2, Name = "Good2" },
            new Product { Id = 3, Name = "Good3" },
            new Product { Id = 4, Name = "Good4" },
            new Product { Id = 5, Name = "Good5" },
        }).AsQueryable());
        var controller = new HomeController(mock.Object);

        var model = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var pagingInfo = model.PagingInfo;
        Assert.Equal(2, pagingInfo.CurrentPage);
        Assert.Equal(4, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalCountItems);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
}