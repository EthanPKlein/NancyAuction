using Nancy;

namespace NancyAuction.Modules
{
    public class AuctionModule : NancyModule
    {

        public AuctionModule()
        {

            Get["/home"] = async (ctx, cx) => {
                return View["home.sshtml"];
            };

        }

    }
}
