﻿using System;
using System.Collections.Generic;
using System.Linq;
using NancyAuction.Models;

namespace NancyAuction.Data
{
    public static class Repository
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

        public static void AddBidToAuctionEntry(int id, string bidderName, float amount)
        {
            var auctionItem = _auctionEntries.First(i => i.Id == id);
            var newBidAmount = amount;
            auctionItem.AddBid(bidderName, newBidAmount);
        }

        public static AuctionEntry GetAuctionEntry(int id)
        {
            return _auctionEntries.First(i => i.Id == id);
        }

        public static void DeleteAuctionEntry(int id)
        {
            var auctionItem = _auctionEntries.FirstOrDefault(i => i.Id == id);

            if (auctionItem == null)
            {
                throw new ArgumentNullException("Auction item does not exist!");
            }

            _auctionEntries = _auctionEntries.Where(i => i.Id != id).ToList();
        }

    }
}