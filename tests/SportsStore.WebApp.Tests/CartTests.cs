using System;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Tests
{
    public class CartTests
    {
        [Fact]
        public void CanAddNewLines()
        {
            // Arrange
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);

            CartLine[] result = target.Lines.ToArray();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal(p1, result[0].Product);
            Assert.Equal(p2, result[1].Product);
        }

        [Fact]
        public void CanAddQuantityForExistingLines()
        {
            // Arrage
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            target.AddItem(p1, 10);

            CartLine[] result = (target.Lines ?? new())
                .OrderBy(p => p.Product.ProductId)
                .ToArray();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal(11, result[0].Quantity);
            Assert.Equal(2, result[1].Quantity);
        }

        [Fact]
        public void CanRemoveLine()
        {
            // Arrage
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };
            Product p3 = new Product { ProductId = 3, Name = "P3" };

            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.RemoveLine(p2);
           
            // Assert
            Assert.Empty(target.Lines.Where(x => x.Product == p2));
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void CalculateCartTotal()
        {
            // Arrage
            Product p1 = new Product { ProductId = 1, Name = "P1", Price = 100m };
            Product p2 = new Product { ProductId = 2, Name = "P2", Price = 50m };
      
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
           
            // Assert
            Assert.Equal(450M, target.ComputeTotalValue());
        }
    }
}

