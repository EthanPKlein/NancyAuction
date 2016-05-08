using System;

namespace NancyAuction.Models
{
    public class AuctionEntry
    {
        public int Id { get; set;  }
        public AuctionItem AuctionItem { get; set; }
        public BidHistory BidHistory { get; set; }
        public DateTime BidStartTime { get; set; }
        public DateTime BidEndTime { get; set; }
        public bool IsOpen { get; set; }

        public AuctionEntry()
        {
            this.BidStartTime = DateTime.UtcNow;
            this.BidHistory = new BidHistory();
            this.IsOpen = false;
        }

        public void AddBid(string bidderName, float bidAmount)
        {
            this.BidHistory.AddBid(bidderName, bidAmount);
        }

    }

}