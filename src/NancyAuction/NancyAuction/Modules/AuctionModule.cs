using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction.Modules
{
    public class AuctionModule : NancyModule
    {

        public AuctionModule() : base("/simpleAuction")
        {

            Get["/"] = _ =>
            {
                var data = Repository.GetAuctionEntries();
                return View["home.sshtml", data];
            };

            Get["/entries/{id}"] = parameters =>
            {
                int id = parameters.id;
                var data = Repository.GetAuctionEntry(id);
                return View["auctionEntryDetail.sshtml", data];
            };

            Post["/bid/"] = parameters =>
            {
                var newBid = this.Bind<NewBid>();
                var auctionEntry = Repository.GetAuctionEntry(newBid.AuctionEntryId);

                if (auctionEntry.BidIsEligible(newBid.BidAmount))
                {
                    Repository.AddBidToAuctionEntry(newBid.AuctionEntryId, newBid.BidderName, newBid.BidAmount);
                }

                return Response.AsRedirect("/simpleAuction/");

            };

            Get["/entries/delete/{id}"] = parameters =>
            {
                int id = parameters.id;
                Repository.DeleteAuctionEntry(id);

                return Response.AsRedirect("/simpleAuction/");
            };

            Get["/newEntry"] = _ =>
            {
                return View["newEntry.sshtml"];
            };

            Post["/newEntry"] = _ =>
            {
                var newItems = this.Bind<List<AuctionItem>>();

                foreach (AuctionItem a in newItems)
                {
                    AuctionEntry entry = new AuctionEntry(a)
                    {
                        Id = (int)(new Random().NextDouble() * 1000),
                        IsOpen = true
                    };
                    Repository.AddAuctionEntry(entry);
                }

                return Response.AsRedirect("/simpleAuction/");
            };

            Get["/unitTestPass"] = _ =>
            {
                return HttpStatusCode.OK;
            };

        }

    }
}
