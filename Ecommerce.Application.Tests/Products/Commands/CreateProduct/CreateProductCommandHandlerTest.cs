using AutoMapper;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ecommerce.Application.Tests.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandlerTest
    {
        [Fact]
        public async Task HandleCreateTest()
        {
            // Arrange
            var mockProductsRepo = new Mock<IProductsRepository>();
            mockProductsRepo.Setup(repo => repo.Create(It.IsAny<Product>())).ReturnsAsync(Guid.NewGuid());
            var mockLogger = new Mock<ILogger<CreateProductCommandHandler>>();
            var mockMapper = new Mock<IMapper>();
            var command = new CreateProductCommand();
            var Product = new Product();
            mockMapper.Setup(m => m.Map<Product>(command)).Returns(Product);
            var commandHandler = new CreateProductCommandHandler(mockProductsRepo.Object,mockLogger.Object,mockMapper.Object);
            
            // Act
            var result = await commandHandler.Handle(command,default);

            // Assert
            Xunit.Assert.IsType<Guid>(result);
            mockProductsRepo.Verify(r=>r.Create(Product), Times.Once);
        }
    }
}
