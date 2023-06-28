using System;
using Moq;
using SportsStore.WebApp.Components;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void CanSelectCategory()
        {
            // Arrange
            var mock = new Mock<IStoreRepository>();
            mock.Setup(x => x.Products)
                .Returns((new Product[]
                {
                    new Product { ProductId = 1, Name = "P1", Category = "Apples"},
                    new Product { ProductId = 2, Name = "P2", Category = "Apples"},
                    new Product { ProductId = 3, Name = "P3", Category = "Plums"},
                    new Product { ProductId = 4, Name = "P4", Category = "Oranges"},
                }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            // Act
            string[] results = ((IEnumerable<string>?)(target.Invoke() as NavigationMenuViewComponent)?.ViewData?.Model
                ?? Enumerable.Empty<string>()).ToArray();

            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plugms" }, results));

        }
    }
}

