using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Auction
{
    public class AuctionGoodAuctioner
    {
        public int Id { get; set; }
        public string GoodTtile { get; set; }
        public int GoodId { get; set; }
        public DateTime GoodCreateAt { get; set; }
        public decimal GoodFirstPrice { get; set; }

        public string AuctionerFirstName { get; set; }

        public string AuctionerLastName { get; set; }
        public int AuctionerId { get; set; }
        public decimal? MaxPrice { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
