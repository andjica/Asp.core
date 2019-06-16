using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Auction
{
    public class AddAuctionDto
    {
        [Required(ErrorMessage = "Must have some Auctioner")]
        public int AuctionerId { get; set; }

        [Required(ErrorMessage = "GoodId is required field")]
        public int GoodId { get; set; }


        public DateTime? ValidUntil { get; set; }

        [Required(ErrorMessage = "Max Price field is required")]
        //[RegularExpression(@"^\d+(.\d{1,2})?$")]
        public decimal? MaxPrice { get; set; }
    }
}
