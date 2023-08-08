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
            // return bad request when the input list is null or contains an id not part of the catalogue
            if (watchIdList == null || watchIdList.Count == 0 || !watchIdList.All(id => _checkoutService.WatchCatalogue_RO.Any(w => w.WatchId == id)))
            {
                return BadRequest();
            }

            decimal resPrice = _checkoutService.CalculatePrice(watchIdList);
            var response = new
            {
                price = resPrice
            };
            return Ok(response);
        }
    }
}