using Nancy;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction.Modules
{
    public class AuctionModule : NancyModule
    {

        public AuctionModule()
        {

            Get["/home"] = _ =>
            {
                return View["home.sshtml"];
            };

            Get["/entries"] = _ =>
            {
                var data = AuctionList.GetAuctionEntries();
                return data;
            };

        }

    }
}
