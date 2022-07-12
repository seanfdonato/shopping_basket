namespace Domain.Model
{
    public class Discount
    {
        public Discount(
            int productId,
            int productIdDescountTarget,
            double porcentDescount,
            string discountName,
            DiscountType discountType,
            int minAmount)
        {
            ProductId = productId;
            ProductIdDescountTarget = productIdDescountTarget;
            PorcentDescount = porcentDescount;
            DiscountName = discountName;
            DiscountType = discountType;
            MinAmount = minAmount;
        }

        public int ProductId { get; set; }

        public int ProductIdDescountTarget { get; set; }

        public double PorcentDescount { get; set; }

        public string DiscountName { get; set; }

        public DiscountType DiscountType { get; set; }

        public int MinAmount { get; set; }
    }
}
