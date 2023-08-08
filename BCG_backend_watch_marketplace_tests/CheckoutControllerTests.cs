using BCG_backend_watch_marketplace;
using BCG_backend_watch_marketplace.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BCG_backend_watch_marketplace_tests
{
    [TestFixture]
    public class CheckoutControllerTests
    {
        private CheckoutController _checkoutController;
        private Mock<CheckoutService> _mockCheckoutService;

        [SetUp]
        public void Setup()
        {
            _mockCheckoutService = new Mock<CheckoutService>();
            _checkoutController = new CheckoutController(_mockCheckoutService.Object);
        }

        [Test]
        public void CalculatePrice_ValidInput()
        {
            var watchIdList = new List<string> { "001", "002", "003" };
            decimal resPrice = 200;
            _mockCheckoutService.Setup(s => s.CalculatePrice(watchIdList)).Returns(resPrice);

            var result = _checkoutController.CalculatePrice(watchIdList) as OkObjectResult;

            var expectedValue = "{ price = 200 }";
            Assert.AreEqual(expectedValue, result.Value.ToString());
        }

        [Test]
        public void CalculatePrice_InvalidWatchId()
        {
            var watchIdList = new List<string> { "001", "002", "999" };
            var result = _checkoutController.CalculatePrice(watchIdList) as BadRequestResult;

            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode); 
        }

        [Test]
        public void CalculatePrice_NullInput()
        {
            var result = _checkoutController.CalculatePrice(null) as BadRequestResult;

            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode); 
        }

        [Test]
        public void CalculatePrice_NoWatches()
        {
            var result = _checkoutController.CalculatePrice(new List<string>()) as BadRequestResult;

            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode); 
        }
    }
}
