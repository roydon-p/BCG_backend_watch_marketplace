namespace BCG_backend_watch_marketplace.Models{
    public class Watch
    {
        public string? WatchId { get; set; }
        public string? WatchName { get; set; }
        public decimal UnitPrice { get; set; }
        public int DiscountQuantity { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}