using System;
using System.Collections.Generic;

namespace NancyAuction.Models
{
    public class BidHistory
    {
        public List<Bid> Bids { get; set; }

        public BidHistory()
        {
            this.Bids = new List<Bid>();
        }

        public void AddBid(string BidderName, float Amount)
        {
            Bid newbid = new Bid
            {
                BidAmount = Amount,
                BidderName = BidderName,
                BidTime = DateTime.UtcNow
            };
            this.Bids.Add(newbid);
        }
    }
}