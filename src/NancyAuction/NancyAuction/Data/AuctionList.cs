using System.Collections.Generic;
using System.Linq;
using NancyAuction.Models;

namespace NancyAuction.Data
{
    public static class AuctionList
    {
        private static List<AuctionEntry> _auctionEntries = new List<AuctionEntry>();

        public static void AddAuctionEntry(AuctionEntry entry)
        {
            _auctionEntries.Add(entry);
        }

        public static List<AuctionEntry> GetAuctionEntries()
        {
            return _auctionEntries;
        }

        public static void AddBidToAuctionEntry(int id)
        {
            var auctionItem = _auctionEntries.First(i => i.Id == id);
            var newBidAmount = auctionItem.BidHistory.GetTopBid().BidAmount + 5;
            auctionItem.AddBid("Anonymous", newBidAmount);
        }

        public static AuctionEntry GetAuctionEntry(int id)
        {
            return _auctionEntries.First(i => i.Id == id);
        }

        public static void DeleteAuctionEntry(int id)
        {
            _auctionEntries = _auctionEntries.Where(i => i.Id != id).ToList();
        }

    }
}