namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repository;
    using Domain.Model;

    public class BasketService
    {
        private readonly ProductRepository productRepository;
        private readonly DiscountRepository discountRepository;

        public BasketService(ProductRepository productRepository, DiscountRepository discountRepository)
        {
            this.productRepository = productRepository;
            this.discountRepository = discountRepository;
        }

        public BasketResult GetBasket(string[] productNames)
        {
            var producRequestResult = this.GetProducts(productNames);

            var discounts = this.GetDiscounts(producRequestResult.Products.Select(p => p.ProductId).ToArray());

            ProcessPrices(producRequestResult, discounts);

            return producRequestResult;
        }

        private BasketResult GetProducts(string[] productNames)
        {
            var result = new BasketResult();

            foreach (var productName in productNames)
            {
                var product = this.productRepository.GetProduct(productName);

                if (product is null)
                {
                    result.Fails.Add(productName);
                    continue;
                }

                result.AddProduct(product);
            }

            return result;
        }

        private List<Discount> GetDiscounts(int[] productIds)
        {
            var discounts = new List<Discount>();

            foreach (var productId in productIds)
            {
                var discount = this.discountRepository.GetDiscount(productId);

                if (discount != null)
                {
                    discounts.Add(discount);
                }
            }

            return discounts;
        }

        private void ProcessPrices(BasketResult basketResult, List<Discount> discounts)
        {
            foreach (var product in basketResult.Products)
            {
                var discount = discounts.Where(d => d.ProductIdDescountTarget.Equals(product.ProductId));

                if (discount.Any())
                {
                    ProcessDiscount(product, basketResult, discount);
                }
            }

            basketResult.Subtotal = basketResult.Products.Sum(p => p.Price * p.Quantity);
            basketResult.Total = basketResult.Products.Sum(p => p.FinalPrice * p.Quantity);
        }

        private void ProcessDiscount(Product product, BasketResult basketResult, IEnumerable<Discount> discounts)
        {
            foreach (var discount in discounts)
            {
                if (discount.DiscountType == DiscountType.Multibuy)
                {
                    var discountProduct = basketResult.Products.First(p => p.ProductId.Equals(discount.ProductId));

                    if (discountProduct.Quantity < discount.MinAmount)
                    {
                        return;
                    }
                }
                var discountValue = product.FinalPrice * discount.PorcentDescount;

                product.FinalPrice -= discountValue;

                basketResult.AppliedDiscounts.Add($"{discount.DiscountName}: -€{discountValue}");
            }
        }
    }
}
