namespace Domain.Model
{
    public class Product
    {
        public Product(int productId, string name, double price)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.FinalPrice = price;
        }
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double FinalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
