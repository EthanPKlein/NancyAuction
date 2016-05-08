using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyAuction.Models
{
    public class Bid
    {
        public string BidderName { get; set; }
        public float BidAmount { get; set; }
        public DateTime BidTime { get; set; }
    }
}