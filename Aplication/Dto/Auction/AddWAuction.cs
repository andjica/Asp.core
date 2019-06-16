using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Auction
{
    public class AddWAuction
    {
        [Required]
        public int AuctionerId { get; set; }

        [Required]
        public int GoodId { get; set; }


        [Required]
        public decimal? MaxPrice { get; set; }
    }
}
