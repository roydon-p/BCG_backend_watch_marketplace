using BCG_backend_watch_marketplace.Services;

namespace BCG_backend_watch_marketplace_tests
{
    [TestFixture]
    public class CheckoutServiceTests
    {
        private CheckoutService _checkoutService;

        [SetUp]
        public void Setup()
        {
            _checkoutService = new CheckoutService();
        }

        [Test]
        public void CalculatePrice_NoDiscountIds()
        {
            var watchIdList = new List<string> { "003", "004" }; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(80, total_price); 
        }

        [Test]
        public void CalculatePrice_NoDiscountApplicable()
        {
            var watchIdList = new List<string> { "001", "001", "002" }; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(280, total_price); 
        }

        [Test]
        public void CalculatePrice_SingleDiscountApplied()
        {
            var watchIdList = new List<string> { "001", "001", "001" }; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(200, total_price); 
        }

        [Test]
        public void CalculatePrice_MultipleDiscountsApplied()
        {
            var watchIdList = new List<string> { "001", "001", "001", "002", "002", "002" }; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(400, total_price); 
        }

        [Test]
        public void CalculatePrice_SameIdMultipleDiscountsApplied()
        {
            var watchIdList = new List<string> { "001", "002", "002", "002", "002", "002" }; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(420, total_price); 
        }

        [Test]
        public void CalculatePrice_NoInput()
        {
            var watchIdList = new List<string> {}; 
            decimal total_price = _checkoutService.CalculatePrice(watchIdList);
            Assert.AreEqual(0, total_price); 
        }
    }
}
