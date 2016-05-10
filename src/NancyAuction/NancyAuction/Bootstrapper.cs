using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            // import some default auction items
            AuctionItem item = new AuctionItem
            {
                AutoBuy = 100,
                Id = 100,
                Description = "A small white pearl",
                StartingBid = 25,
                Name = "Small White Pearl",
                OwnerName = "Sam Carter"
            };

            AuctionEntry entry = new AuctionEntry(item)
            {
                IsOpen = true
            };

            entry.AddBid("Gary", 30);
            entry.AddBid("Susan", 35);

            AuctionList.AddAuctionEntry(entry);

            // import some default auction items
            AuctionItem item2 = new AuctionItem
            {
                AutoBuy = 100,
                Id = 18,
                Description = "A pair of knitted socks that will keep your toes very toasty!",
                StartingBid = 12,
                Name = "Knitted socks",
                OwnerName = "Eileen Summers"
            };

            AuctionEntry entry2 = new AuctionEntry(item2)
            {
                IsOpen = true
            };

            entry2.AddBid("Laura", 12);

            AuctionList.AddAuctionEntry(entry2);

            // import some default auction items
            AuctionItem item3 = new AuctionItem
            {
                AutoBuy = 500,
                Id = 47,
                Description = "A frisbee made of solid gold!  Disclaimer:  Does not fly very well.",
                StartingBid = 100,
                Name = "Gold Frisbee",
                OwnerName = "Richard Moneybags"
            };

            AuctionEntry entry3 = new AuctionEntry(item3)
            {
                IsOpen = true
            };

            entry3.AddBid("Greedo", 150);
            entry3.AddBid("Han", 175);
            entry3.AddBid("Greedo", 250);
            entry3.AddBid("Han", 280);
            entry3.AddBid("Greedo", 350);
            entry3.AddBid("Darth Vader", 500);

            AuctionList.AddAuctionEntry(entry3);
        }
    }
}