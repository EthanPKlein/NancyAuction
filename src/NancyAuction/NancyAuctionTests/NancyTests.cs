
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
            // Given
            //var bootstrapper = new NancyAuction.Bootstrapper();
            //var browser = new Browser(bootstrapper);

            var browser = new Browser(with => with.Module(new NancyAuction.Modules.AuctionModule()));

            // When
            var result = browser.Get("/simpleAuction/", with => {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

    }
}
