﻿using System.Collections.Generic;
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

        public static AuctionEntry GetAuctionEntry(int Id)
        {
            return _auctionEntries.First(i => i.Id == Id);
        }

    }
}