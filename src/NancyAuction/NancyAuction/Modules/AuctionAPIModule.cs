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
                var output = Repository.GetAuctionEntry(id);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("applicaton/json")
                    .WithModel(output);
            };

            Get["/entries"] = _ =>
            {
                var output = Repository.GetAuctionEntries();

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("applicaton/json")
                    .WithModel(output);
            };

            Delete["/entry/{id}"] = parameters =>
            {
                int id = parameters.id;
                try
                {
                    Repository.DeleteAuctionEntry(id);
                }
                catch
                {
                    return Negotiate
                    .WithStatusCode(HttpStatusCode.InternalServerError);
                }

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}