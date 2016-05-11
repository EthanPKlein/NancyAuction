using Nancy;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction.Modules
{
    public class AuctionModule : NancyModule
    {

        public AuctionModule()
        {

            Get["/"] = _ =>
            {
                var data = AuctionList.GetAuctionEntries();
                return View["home.sshtml", data];
            };

            Get["/entries"] = _ =>
            {
                var data = AuctionList.GetAuctionEntries();
                return data;
            };

            Get["/entries/{id}"] = parameters =>
            {
                int id = parameters.id;
                var data = AuctionList.GetAuctionEntry(id);
                return data;
            };

            Get["/newEntry"] = _ =>
            {
                return View["newEntry.sshtml"];
            };

            Post["/newEntry"] = _ =>
            {
                var data = AuctionList.GetAuctionEntries();
                return View["home.sshtml", data];
            };

        }

    }
}
