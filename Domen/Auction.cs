using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Auction : BaseEntity 
    {
        public int AuctionerId { get; set; }

        public int GoodId { get; set; }

        public DateTime ValidUntil { get; set; }

        public decimal? MaxPrice { get; set; }

        public Auctioner Auctioner { get; set; }

        public Good Good { get; set; }
    }
}
