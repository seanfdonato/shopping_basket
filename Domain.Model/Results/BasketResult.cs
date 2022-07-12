namespace Domain.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class BasketResult
    {
        public BasketResult()
        {
            this.Products = new List<Product>();
            this.Fails = new List<string>();
            this.AppliedDiscounts = new List<string>();
        }

        public List<Product> Products { get; private set; }

        public List<string> Fails { get; set; }

        public List<string> AppliedDiscounts { get; set; }

        public double Subtotal { get; set; }

        public double Total { get; set; }

        public void AddProduct(Product product)
        {
            var existentProduct = this.Products.FirstOrDefault(p => p.ProductId.Equals(product.ProductId));

            if (existentProduct is null)
            {
                product.Quantity++;
                this.Products.Add(product);
                return;
            }

            existentProduct.Quantity++;
        }
    }
}
