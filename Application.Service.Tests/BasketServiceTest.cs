namespace Application.Service.Tests
{
    using Application.Services;
    using Data.Repository;
    using Xunit;

    public class BasketServiceTest
    {
        private readonly BasketService serivce = new BasketService(new ProductRepository(), new DiscountRepository());

        [Fact]
        public void BasketService_GetBasket_WhenProductHasNoDiscount_ShouldReturnProduct()
        {
            // Arrange
            var expectedTotal = 2.75;
            string[] produtsName = { "soup", "bread", "milk" };

            // Act
            var result = this.serivce.GetBasket(produtsName);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Fails);
            Assert.Empty(result.AppliedDiscounts);
            Assert.Equal(expectedTotal, result.Subtotal);
            Assert.Equal(expectedTotal, result.Total);
        }

        [Fact]
        public void BasketService_GetBasket_WhenProductHasDiscount_ShouldReturnProductWithDiscount()
        {
            // Arrange
            var expectedTotal = 3.9;
            var expectedSubTotal = 4.4;
            string[] produtsName = { "soup", "bread", "milk", "soup", "Apples" };

            // Act
            var result = this.serivce.GetBasket(produtsName);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Fails);
            Assert.NotEmpty(result.AppliedDiscounts);
            Assert.Equal(expectedTotal, result.Total);
            Assert.Equal(expectedSubTotal, result.Subtotal);
        }

        [Fact]
        public void BasketService_GetBasket_WhenProductNotExists_ShouldReturnFailure()
        {
            // Arrange
            string[] produtsName = { "carrots" };

            // Act
            var result = this.serivce.GetBasket(produtsName);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Fails);
        }
    }
}