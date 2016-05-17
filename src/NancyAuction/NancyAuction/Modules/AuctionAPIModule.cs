using Nancy;
using Nancy.ModelBinding;
using NancyAuction.Data;
using NancyAuction.Models;

namespace NancyAuction.Modules
{
    public class AuctionAPIModule : NancyModule
    {
        public AuctionAPIModule() : base("/api")
        {

            Get["/template"] = _ =>
            {
                return View["template.html"];
            };

            Get["/entry/{id}"] = parameters =>
            {
                int id = parameters.id;
                var output = AuctionList.GetAuctionEntry(id);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("applicaton/json")
                    .WithModel(output);
            };

            Get["/entries"] = _ =>
            {
                var output = AuctionList.GetAuctionEntries();

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("applicaton/json")
                    .WithModel(output);
            };
        }
    }
}