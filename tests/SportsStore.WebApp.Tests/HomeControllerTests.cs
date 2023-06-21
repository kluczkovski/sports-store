using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.WebApp.Controllers;
using SportsStore.WebApp.Models;
using SportsStore.WebApp.Models.ViewModels;

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
        var result = controller.Index()?.ViewData.Model as ProductsListViewModel ?? new();

        // Assert
        Product[] productArray = result.Products.ToArray();
        Assert.True(productArray.Length == 2);
        Assert.Equal("P1", productArray[0].Name);
        Assert.Equal("P2", productArray[1].Name);

    }

    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        // Arrange
        var mock = new Mock<IStoreRepository>();
        mock.Setup(x => x.Products)
            .Returns((new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 1, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" },
            }).AsQueryable<Product>());

        var controller = new HomeController(mock.Object);

        // Act
        var result = controller.Index(2)?.ViewData.Model as ProductsListViewModel ?? new();

        // Assert
        var pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(3, pageInfo.ItemsPerPage);
        Assert.Equal(5, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPage);
    }

    [Fact]
    public void CanPaginete()
    {
        // arrange
        Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products)
            .Returns((new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" },
            }).AsQueryable<Product>());

        var controller = new HomeController(mock.Object);


        // Act
        var result = controller.Index(2)?.ViewData.Model as ProductsListViewModel ?? new();

        //
        Product[] productArray = result.Products.ToArray();
        Assert.True(productArray.Length == 2);
        Assert.Equal("P4", productArray[0].Name);
        Assert.Equal("P5", productArray[1].Name);
    }
}