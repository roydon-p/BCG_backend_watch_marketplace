using Microsoft.AspNetCore.Mvc;
using BCG_backend_watch_marketplace.Services;

namespace BCG_backend_watch_marketplace 
{
    [ApiController]
    [Route("checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService _checkoutService;

        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public IActionResult CalculatePrice([FromBody] List<string> watchIdList)
        {
            decimal resPrice = _checkoutService.CalculatePrice(watchIdList);
            var response = new
            {
                price = resPrice
            };
            return Ok(response);
        }
    }
}