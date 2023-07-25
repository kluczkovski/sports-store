using System;
namespace SportsStore.WebApp.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public Cart()
        {

        }

        public virtual void AddItem(Product product, int quantity)
        {
            var line = Lines
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => 
           Lines.RemoveAll(x => x.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() =>
            Lines.Sum(x => x.Product.Price * x.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}

