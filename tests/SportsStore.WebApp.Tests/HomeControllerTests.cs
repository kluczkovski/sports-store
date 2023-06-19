using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.WebApp.Controllers;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Tests;

public class HomeControllerTests
{
    [Fact]
    public void CanUseRepository()
    {
        // Arrange
        Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
        mock.Setup(x => x.Products)
            .Returns((new Product[] {
                new Product { ProductId = 1, Name = "P1"},
                new Product { ProductId = 2, Name = "P2"} }).AsQueryable<Product>());

        var controller = new HomeController(mock.Object);

        // Act
        var result = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        // Assert
        Product[] productArray = result?.ToArray() ?? Array.Empty<Product>();
        Assert.True(productArray.Length == 2);
        Assert.Equal("P1", productArray[0].Name);
        Assert.Equal("P2", productArray[1].Name);

    }
}