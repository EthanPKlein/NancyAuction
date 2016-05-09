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

            AuctionEntry entry2 = new AuctionEntry(item)
            {
                IsOpen = true
            };

            AuctionList.AddAuctionEntry(entry2);
        }
    }
}