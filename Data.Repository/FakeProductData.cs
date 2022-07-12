namespace Data.Repository
{
    using System.Collections.Generic;
    using Domain.Model;

    internal class FakeProductData
    {
        internal readonly IEnumerable<Product> ProductsData = new List<Product>
        {
            new Product(1, "soup", 0.65),
            new Product(2, "bread", 0.80),
            new Product(3, "milk", 1.30),
            new Product(4, "apples", 1),
        };
    }
}
