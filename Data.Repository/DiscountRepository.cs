namespace Data.Repository
{
    using System.Linq;
    using Domain.Model;

    public class DiscountRepository
    {
        public Discount GetDiscount(int productId)
        {
            return new FakeDiscountData().DiscountData
                .FirstOrDefault(p => p.ProductId.Equals(productId));
        }
    }
}
