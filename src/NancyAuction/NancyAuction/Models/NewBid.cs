namespace NancyAuction.Models
{
    public class NewBid
    {
        public int AuctionEntryId { get; set; }
        public string BidderName { get; set; }
        public float BidAmount { get; set; }
    }
}