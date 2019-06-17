using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Auction
{
    public class AuctionDto
    {

        public int Id { get; set; }

        public int AuctionerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GoodId { get; set; }

        public string GoodTitle { get; set; }

        public DateTime? CreateAt { get; set; }
        public DateTime? ValidUntil { get; set; }

        
        public decimal? MaxPrice { get; set; }

    }
}
