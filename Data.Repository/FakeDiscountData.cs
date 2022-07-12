namespace Data.Repository
{
    using System.Collections.Generic;
    using Domain.Model;

    internal class FakeDiscountData
    {
        internal readonly IEnumerable<Discount> DiscountData = new List<Discount>
        {
            new Discount(1, 2, 0.50, "Bread 50% off", DiscountType.Multibuy, 2),
            new Discount(4, 4, 0.10, "Apples 10% off", DiscountType.Item, 1),
        };
    }
}
