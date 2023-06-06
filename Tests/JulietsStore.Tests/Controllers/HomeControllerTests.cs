namespace JulietsStore.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Index_SendRequest_ShouldOk()
    {
        var loggerStub = Mock.Of<ILogger<HomeController>>();
        var controller = new HomeController(loggerStub);

        var actual = controller.Index();

        Assert.IsType<ViewResult>(actual);
    }
}