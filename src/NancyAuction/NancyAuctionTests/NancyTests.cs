
using Nancy;
using Nancy.Testing;
using NUnit.Framework;


namespace NancyAuctionTests
{

    public class NancyTests
    {

        [Test]
        public void Should_return_status_ok_when_route_exists()
        {

            var browser = new Browser(with => with.Module(new NancyAuction.Modules.AuctionModule()));

            var result = browser.Get("simpleAuction/unitTestPass", with => {
                with.HttpRequest();
            });

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void Should_return_status_ok_when_view_exists()
        {

            var browser = new Browser(new NancyAuction.Bootstrapper());


            var result = browser.Get("simpleAuction/");

            var response = browser.Get("/login", (with) => { ​
                with.HttpRequest(); ​
                with.Query("error", "true"); ​
                with.Body("body");
                with.Certificate();
            });

            // failing because the views aren't being routed properly.  This should be handled in a bootstrapper.
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

    }
}
