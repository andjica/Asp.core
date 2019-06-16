using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Auction
{
    public class EditAuction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Auctioner Id is required filed")]
        public int AuctionerId { get; set; }

        [Required(ErrorMessage = "GoodId Id is required filed")]
        public int GoodId { get; set; }

        [Required(ErrorMessage = "MaxPrice Id is required filed")]
        public decimal? MaxPrice { get; set; }
    }
}
