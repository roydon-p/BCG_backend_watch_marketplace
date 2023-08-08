
using BCG_backend_watch_marketplace.Models;

namespace BCG_backend_watch_marketplace.Services
{
    public class CheckoutService
    {
        private readonly List<Watch> watchCatalogue;

        public CheckoutService()
        {
            // intialize the watch catalogue based on data provided. This part can be moved to database later if required.
            watchCatalogue = new List<Watch>
            {
                new Watch { WatchId = "001", WatchName = "Rolex", UnitPrice = 100, DiscountQuantity = 3, DiscountPrice = 200 },
                new Watch { WatchId = "002", WatchName = "Michael Kors", UnitPrice = 80, DiscountQuantity = 2, DiscountPrice = 120 },
                new Watch { WatchId = "003", WatchName = "Swatch", UnitPrice = 50 },
                new Watch { WatchId = "004", WatchName = "Casio", UnitPrice = 30 }
            };
        }

        public decimal CalculatePrice(List<string> watchIdList) 
        {
            decimal total_price = 0;
            // run the loop over distinct id's from the input list of id's
            foreach (var watchId in watchIdList.Distinct())
            {
                var curr_watch = watchCatalogue.FirstOrDefault(w => w.WatchId == watchId);
                if (curr_watch != null)
                {
                    // get the total count of current watch in the input list of id's
                    int curr_watch_count = watchIdList.Count(id => id == watchId);
                    
                    // do this if discount is applicable to current watch type
                    if (curr_watch.DiscountQuantity > 0 && curr_watch_count >= curr_watch.DiscountQuantity)
                    {
                        // get the count of current watch on which discount can be applied
                        int discountAppliedToCount = curr_watch_count / curr_watch.DiscountQuantity;

                        // get the count of current watch on which discount cannot be applied
                        int noDiscountAppliedToCount = curr_watch_count % curr_watch.DiscountQuantity;
                        
                        // calculate the total price for the current watch id
                        total_price += (discountAppliedToCount * curr_watch.DiscountPrice) + (noDiscountAppliedToCount * curr_watch.UnitPrice);
                    }
                    // do this if discount is not applicable to current watch type
                    else
                    {
                        total_price += curr_watch_count * curr_watch.UnitPrice;
                    }
                }
            }
            return total_price;
        }
    }
}
