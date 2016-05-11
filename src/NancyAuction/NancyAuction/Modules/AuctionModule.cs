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
                var newItems = this.Bind<List<AuctionItem>>();

                foreach (AuctionItem a in newItems)
                {
                    AuctionEntry entry = new AuctionEntry(a)
                    {
                        Id = (int)(new Random().NextDouble()*1000),
                        IsOpen = true
                    };
                    AuctionList.AddAuctionEntry(entry);
                }
                
                var data = AuctionList.GetAuctionEntries();
                return View["home.sshtml", data]; // TODO: redirect to home?
            };

        }

    }
}
