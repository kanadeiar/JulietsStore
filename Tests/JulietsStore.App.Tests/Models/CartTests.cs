using JulietsStore.App.Models;
using JulietsStore.Domain.Models;

namespace JulietsStore.App.Tests.Models;

public class CartTests
{
    [Fact]
    public void Add_CanAddNewLines_ShouldOk()
    {
        var p1 = new Product { Id = 1, Name = "Good1" };
        var p2 = new Product { Id = 2, Name = "Good2" };
        var cart = new Cart();

        cart.AddItem(p1, 1);
        cart.AddItem(p2, 2);
        var results = cart.Lines.ToArray();

        Assert.Equal(2, results.Length);
        Assert.Equal(p1, results[0].Product);
        Assert.Equal(p2, results[1].Product);
    }
    [Fact]
    public void Add_CanAddQuantity_ShouldOk()
    {
        var p1 = new Product { Id = 1, Name = "Good1" };
        var p2 = new Product { Id = 2, Name = "Good2" };
        var cart = new Cart();
        cart.AddItem(p2, 1);
        cart.AddItem(p1, 1);

        cart.AddItem(p1, 10);
        var results = cart.Lines.ToArray();

        Assert.Equal(2, results.Length);
        Assert.Equal(1, results[0].Quantity);
        Assert.Equal(11, results[1].Quantity);
    }
    [Fact]
    public void RemoveLine_CanRemove_ShouldOk()
    {
        var p1 = new Product { Id = 1, Name = "Good1" };
        var p2 = new Product { Id = 2, Name = "Good2" };
        var p3 = new Product { Id = 3, Name = "Good3" };
        var cart = new Cart();
        cart.AddItem(p1, 1);
        cart.AddItem(p2, 1);
        cart.AddItem(p3, 1);

        cart.RemoveLine(p2);
        var results = cart.Lines.ToArray();

        Assert.Empty(results.Where(x => x.Product == p2));
        Assert.Equal(2, results.Count());
    }
    [Fact]
    public void TotalSum_CartTotal_ShouldOk()
    {
        var p1 = new Product { Id = 1, Name = "Good1", Price = 100M };
        var p2 = new Product { Id = 2, Name = "Good2", Price = 50M };
        var cart = new Cart();
        cart.AddItem(p1, 4);
        cart.AddItem(p2, 1);

        var result = cart.TotalSum();

        Assert.Equal(450M, result);
    }
    [Fact]
    public void Clear_CanClear_ShouldOk()
    {
        var p1 = new Product { Id = 1, Name = "Good1", Price = 100M };
        var p2 = new Product { Id = 2, Name = "Good2", Price = 50M };
        var cart = new Cart();
        cart.AddItem(p1, 4);
        cart.AddItem(p2, 1);

        cart.Clear();
        var results = cart.Lines;
        
        Assert.Empty(results);
    }
}