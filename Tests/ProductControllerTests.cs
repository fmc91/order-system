using NUnit.Framework;
using Moq;
using DomainLayer;
using DomainLayer.ProductModel;
using Common;
using OrderSystem.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetProductByIdTest()
        {
            var mockProductService = new Mock<IProductService>();
            var mockOrderService = new Mock<IOrderService>();
            var mockDistributionCentreService = new Mock<IDistributionCentreService>();

            mockProductService.Setup(x => x.GetProductByIdAsync(1))
                .ReturnsAsync(new Product(1, 1, "Foo", ProductSize.Small, 99.99m));

            var sut = new ProductController(mockProductService.Object, mockOrderService.Object, mockDistributionCentreService.Object);

            var result = await sut.GetProductAsync(1);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;

            Assert.IsInstanceOf<Product>(okResult.Value);
            var value = (Product)okResult.Value!;

            Assert.IsNotNull(value);

            Assert.AreEqual(1, value.ProductId);
            Assert.AreEqual(1, value.CategoryId);
            Assert.AreEqual("Foo", value.Name);
            Assert.AreEqual(ProductSize.Small, value.Size);
            Assert.AreEqual(99.99m, value.Price);
        }

        [Test]
        public async Task GetProductByIdTest_NotFound()
        {
            var mockProductService = new Mock<IProductService>();
            var mockOrderService = new Mock<IOrderService>();
            var mockDistributionCentreService = new Mock<IDistributionCentreService>();

            mockProductService.Setup(x => x.GetProductByIdAsync(1))
                .Throws(() => new EntityNotFoundException("Foobar"));

            var sut = new ProductController(mockProductService.Object, mockOrderService.Object, mockDistributionCentreService.Object);

            var result = await sut.GetProductAsync(1);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            var notFoundResult = (NotFoundObjectResult)result;

            Assert.AreEqual("Foobar", ((dynamic)notFoundResult.Value!).errorMessage);
        }
    }
}