using Nancy;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction.Modules
{
    public class AuctionModule : NancyModule
    {

        public AuctionModule()
        {

            Get["/home"] = async (ctx, cx) => {
                return View["home.sshtml"];
            };

            Get["/add"] = async (ctx, cx) =>
            {

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

                return null;
            };

        }

    }
}
