using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Products.Validators;
using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
namespace Ecommerce.Application.Tests.Products.Commands.CreateProduct
{
    public class CreateProductHandlerMappingTest
    {
        [Fact]
        public async Task Validator_ForNotValidCommand_ShouldNotHaveValidationErrors()
        {
            // Arrange

            var Product = new CreateProductCommand()
            {
                Name = "ma",
                Description = "matelas confortable",
                PurchasePrice = -2,
                SellPrice = -1,
                UnitsInStock = 50,
                StockLimit = 10
            };
            var validator = new CreateProductCommandValidator();

            // Act
            var result = await validator.TestValidateAsync(Product);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PurchasePrice);
            result.ShouldHaveValidationErrorFor(p => p.SellPrice);
            result.ShouldHaveValidationErrorFor(p => p.Name);

        }

        [Fact()]
        public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            //arrang
            var command = new CreateProductCommand()
            {
                Name = "matelas",
                Description = "matelas confortable",
                PurchasePrice = 300,
                SellPrice = 400,
                UnitsInStock = 50,
                StockLimit = 10
            };

            var validator = new CreateProductCommandValidator();
            //act

            var result = validator.TestValidate(command);

            //assert

            result.ShouldNotHaveValidationErrorFor(p => p.PurchasePrice);
            result.ShouldNotHaveValidationErrorFor(p => p.SellPrice);
            result.ShouldNotHaveValidationErrorFor(p => p.Name);
        }
    }
}
