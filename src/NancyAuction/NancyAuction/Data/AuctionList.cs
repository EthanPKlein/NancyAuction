using System.Collections.Generic;
using NancyAuction.Models;

namespace NancyAuction.Data
{
    public static class AuctionList
    {
        public static List<AuctionEntry> AuctionEntries = new List<AuctionEntry>();

        public static void AddAuctionEntry(AuctionEntry entry)
        {
            AuctionEntries.Add(entry);
        }

    }
}