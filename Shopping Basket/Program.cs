namespace Shopping_Basket
{
    using System;
    using System.Linq;
    using Application.Services;
    using Data.Repository;

    internal class Program
    {
        private static readonly BasketService basketService = new BasketService(new ProductRepository(), new DiscountRepository());

        static void Main(string[] args)
        {
            if (args.Any())
            {
                Process(args);
            }
        }

        static void Process(string[] productNames)
        {
            var result = basketService.GetBasket(productNames);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Shopping Cost");

            if (result.Fails.Any())
            {
                Console.WriteLine($"Whoops! something went wrong, can't find item with the name {string.Join(',', result.Fails)}");

                return;
            }

            Console.WriteLine($"Subtotal: €{result.Subtotal}");

            foreach (var discount in result.AppliedDiscounts)
            {
                Console.WriteLine(discount);
            }

            if (!result.AppliedDiscounts.Any())
            {
                Console.WriteLine("(No offers available)");
            }

            Console.WriteLine($"Total price: €{result.Total}");
        }
    }
}
