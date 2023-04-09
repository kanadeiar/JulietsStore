using JulietsStore.App.Models;
using JulietsStore.ViewModels;

namespace JulietsStore.Tests.Controllers;

public class OrderControllerTests
{
    [Fact]
    public void Checkout_CannotEmptyCart_ShouldInvalid()
    {
        var mockRepo = new Mock<IOrderRepo>();
        var testCart = new Cart();
        var model = new OrderViewModel();
        var controller = new OrderController(mockRepo.Object, testCart);

        var result = controller.Checkout(model) as ViewResult;

        mockRepo.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }

    [Fact]
    public void Checkout_CannotCheckoutInvalid_ShouldShippindDetails()
    {
        var mockRepo = new Mock<IOrderRepo>();
        var testCart = new Cart();
        testCart.AddItem(new Product(), 1);
        var controller = new OrderController(mockRepo.Object, testCart);
        controller.ModelState.AddModelError("", "error");

        var result = controller.Checkout(new OrderViewModel()) as ViewResult;

        mockRepo.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }

    [Fact]
    public void Checkout_CanCheckoutAndSubmit_ShouldOk()
    {
        var mockRepo = new Mock<IOrderRepo>();
        var testCart = new Cart();
        testCart.AddItem(new Product(), 1);
        var controller = new OrderController(mockRepo.Object, testCart);

        var result = controller.Checkout(new OrderViewModel()) as RedirectToActionResult;

        mockRepo.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Once);
        Assert.Equal("Complete", result.ActionName);
    }
}

