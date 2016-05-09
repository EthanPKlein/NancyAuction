namespace NancyAuction.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float StartingBid { get; set; }
        public float AutoBuy { get; set; }
        public string OwnerName { get; set; }
    }
}