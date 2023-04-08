namespace JulietsStore.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Index_CanUseRepo_ShoulOkProducts()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
        };
        var mockRepo = new Mock<IProductsRepo>();
        mockRepo.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mockRepo.Object);

        var model = (controller.Index(null) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.Equal(2, products.Length);
        Assert.Equal(expecteds[0].Name, products[0].Name);
        Assert.Equal(expecteds[1].Name, products[1].Name);
    }
    [Fact]
    public void Index_CanPaginate_ShouldOkPagination()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
            new Product { Id = 3, Name = "Имя3" },
            new Product { Id = 4, Name = "Имя4" },
            new Product { Id = 5, Name = "Имя5" },
            new Product { Id = 6, Name = "Имя6" },
        };
        var mockRepo = new Mock<IProductsRepo>();
        mockRepo.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mockRepo.Object);

        var model = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.Equal(2, products.Length);
        Assert.Equal(expecteds[4].Name, products[0].Name);
        Assert.Equal(expecteds[5].Name, products[1].Name);
    }
    [Fact]
    public void Index_SendPaginationViewModel_ShouldOkModel()
    {
        var mockRepo = new Mock<IProductsRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[] { 
            new Product { Id = 1, Name = "Good1" },
            new Product { Id = 2, Name = "Good2" },
            new Product { Id = 3, Name = "Good3" },
            new Product { Id = 4, Name = "Good4" },
            new Product { Id = 5, Name = "Good5" },
        }).AsQueryable());
        var controller = new HomeController(mockRepo.Object);

        var model = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var pagingInfo = model.PagingInfo;
        Assert.Equal(2, pagingInfo.CurrentPage);
        Assert.Equal(4, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalCountItems);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
    [Fact]
    public void Index_CanFilterProducts_ShouldOkProducts()
    {
        var mockRepo = new Mock<IProductsRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[]{
            new Product { Id = 1, Name = "Good1", Category = "Cat1" },
            new Product { Id = 2, Name = "Good2", Category = "Cat1" },
            new Product { Id = 3, Name = "Good3", Category = "Cat2" },
            new Product { Id = 4, Name = "Good4", Category = "Cat3" },
            new Product { Id = 5, Name = "Good5", Category = "Cat2" },
        }).AsQueryable());
        var controller = new HomeController(mockRepo.Object);

        var model = (controller.Index("Cat2", 1) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();
        
        var products = model.Products.ToArray();

        Assert.Equal(2, products.Count());
        Assert.True(products[0].Name == "Good3" && products[0].Category == "Cat2");
        Assert.True(products[1].Name == "Good5" && products[1].Category == "Cat2");
    }
    [Fact]
    public void Index_GenerateCategoryProductsCount_ShouldOkCounts()
    {
        var mockRepo = new Mock<IProductsRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[]{
            new Product { Id = 1, Name = "Good1", Category = "Cat1" },
            new Product { Id = 2, Name = "Good2", Category = "Cat1" },
            new Product { Id = 3, Name = "Good3", Category = "Cat2" },
            new Product { Id = 4, Name = "Good4", Category = "Cat3" },
            new Product { Id = 5, Name = "Good5", Category = "Cat2" },
        }).AsQueryable);
        var controller = new HomeController(mockRepo.Object);
        Func<IActionResult, ProductsListViewModel?> GetModel = x => (x as ViewResult)?.ViewData?.Model as ProductsListViewModel;

        var res1 = GetModel(controller.Index("Cat1", 1))?.PagingInfo?.TotalCountItems;
        var res2 = GetModel(controller.Index("Cat2", 1))?.PagingInfo?.TotalCountItems;
        var res3 = GetModel(controller.Index("Cat3", 1))?.PagingInfo?.TotalCountItems;
        var res = GetModel(controller.Index(null, 1))?.PagingInfo?.TotalCountItems;

        Assert.Equal(2, res1);
        Assert.Equal(2, res2);
        Assert.Equal(1, res3);
        Assert.Equal(5, res);
    }
}