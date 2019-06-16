using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.SearchEntity.Auction
{
    public class SearchAuctionP
    {
        public decimal? MaxPrice { get; set; }

        public decimal? MinPrice { get; set; }

        public string TitleGood { get; set; }

        public int PerPage { get; set; } = 2;

        public int PageNumber { get; set; } = 1;

        public string NameOFAuctioner { get; set; }

    }
}
