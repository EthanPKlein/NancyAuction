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

        public AuctionModule()
        {

            Get["frontPage", "/"] = _ =>
            {
                var data = AuctionList.GetAuctionEntries();
                return View["home.sshtml", data];
            };

            Get["/entries/{id}"] = parameters =>
            {
                int id = parameters.id;
                var data = AuctionList.GetAuctionEntry(id);
                return View["auctionEntryDetail.sshtml", data];
            };

            Post["/bid/"] = parameters =>
            {
                var newBid = this.Bind<NewBid>();
                var auctionEntry = AuctionList.GetAuctionEntry(newBid.AuctionEntryId);

                if (auctionEntry.BidIsEligible(newBid.BidAmount))
                {
                    AuctionList.AddBidToAuctionEntry(newBid.AuctionEntryId, newBid.BidderName, newBid.BidAmount);
                }

                return Response.AsRedirect("/");

            };

            Get["/entries/delete/{id}"] = parameters =>
            {
                int id = parameters.id;
                AuctionList.DeleteAuctionEntry(id);

                return Response.AsRedirect("/");
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
                    AuctionList.AddAuctionEntry(entry);
                }

                return Response.AsRedirect("/");
            };

        }

    }
}
