using NancyAuction.Models;
using NUnit.Framework;

namespace NancyAuctionTests
{
    [TestFixture]
    public class BidTests
    {
        private string posterName1;
        private string posterName2;

        [SetUp]
        public void SetUp()
        {
            posterName1 = "Bob";
            posterName2 = "Mary";
        }

        [Test]
        public void TestAddBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry();
            auctionEntry.AddBid(posterName1, 50);

            Assert.That(auctionEntry.BidHistory.Bids.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddTwoBid()
        {
            AuctionEntry auctionEntry = new AuctionEntry();
            auctionEntry.AddBid(posterName1, 50);
            auctionEntry.AddBid(posterName2, 65);

            Assert.That(auctionEntry.BidHistory.Bids.Count, Is.EqualTo(2));
        }
    }
}
