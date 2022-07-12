namespace Data.Repository
{
    using System.Linq;
    using Domain.Model;

    public class ProductRepository
    {
        public Product GetProduct(string productName)
        {
            return new FakeProductData().ProductsData
                .FirstOrDefault(p => p.Name.Equals(productName.ToLower()));
        }
    }
}
