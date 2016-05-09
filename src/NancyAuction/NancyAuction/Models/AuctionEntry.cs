﻿using System;

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

        public AuctionEntry(AuctionItem auctionItem)
        {
            this.AuctionItem = auctionItem;
            this.BidStartTime = DateTime.UtcNow;
            this.BidEndTime = DateTime.UtcNow.AddDays(1);
            this.BidHistory = new BidHistory();
            this.IsOpen = false;
        }

        public void AddBid(string bidderName, float bidAmount)
        {

            if (!this.BidHistory.HasBids() && bidAmount < this.AuctionItem.StartingBid)
            {
                throw new Exception("bid amount must be greater or equal to the starting bid");
            }

            if (this.BidHistory.HasBids() && bidAmount <= BidHistory.GetTopBid().BidAmount)
            {
                throw new Exception("bid amount must be greater than the last bid");
            }

            if (bidAmount > this.AuctionItem.AutoBuy)
            {
                bidAmount = this.AuctionItem.AutoBuy;
                this.IsOpen = false;
            }

            this.BidHistory.AddBid(bidderName, bidAmount);
        }

    }

}