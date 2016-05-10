using System;

using NancyAuction.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NancyAuctionTests
{
    [TestFixture]
    public class BidTests
    {
        private string posterName1;
        private string posterName2;
        private AuctionItem auctionItem;

        [SetUp]
        public void SetUp()
        {
            posterName1 = "Bob";
            posterName2 = "Mary";
            auctionItem = new AuctionItem
            {
                AutoBuy = 100,
                Id = 100,
                Description = "A small white pearl",
                StartingBid = 25,
                Name = "Small White Pearl",
                OwnerName = "Sam Carter"

            };
        }

        [Test]
        public void TestAddBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 50);

            Assert.That(auctionEntry.BidHistory.Bids.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddTwoBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 50);
            auctionEntry.AddBid(posterName2, 65);

            Assert.That(auctionEntry.BidHistory.Bids.Count, Is.EqualTo(2));
        }

        [Test]
        public void HighestBidIsUpdated()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 50);
            Assert.That(auctionEntry.BidHistory.GetTopBid().BidAmount, Is.EqualTo(50));

            auctionEntry.AddBid(posterName2, 65);
            Assert.That(auctionEntry.BidHistory.GetTopBid().BidAmount, Is.EqualTo(65));
        }

        [Test]
        public void CantBidLowerOrEqualToLastBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 50);
            Assert.Throws<Exception>(() => auctionEntry.AddBid(posterName1, 45));
        }

        [Test]
        public void BidHigherThanAutoBuyBecomesTopBidAndClosesAuction()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 105);
            Assert.That(auctionEntry.BidHistory.GetTopBid().BidAmount, Is.EqualTo(100));
            Assert.That(auctionEntry.IsOpen, Is.False);
        }

        [Test]
        public void BidExactlyAtAutoBuyBecomesTopBidAndClosesAuction()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            auctionEntry.AddBid(posterName1, 100);
            Assert.That(auctionEntry.BidHistory.GetTopBid().BidAmount, Is.EqualTo(100));
            Assert.That(auctionEntry.IsOpen, Is.False);
        }

        [Test]
        public void BidMustBeHigherThanStartingBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry(auctionItem);
            Assert.Throws<Exception>(() => auctionEntry.AddBid(posterName1, 20));
        }
    }
}
