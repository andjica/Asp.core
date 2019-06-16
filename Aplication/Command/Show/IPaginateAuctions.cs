using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Response;
using Aplication.Interface;
using Aplication.SearchEntity.Auction;
using Aplication.Dto.Auction;
namespace Aplication.Command.Show
{
    public interface IPaginateAuctions : ICommand<SearchAuctionP, PagedResponse<AuctionGoodAuctioner>>
    {
    }
}
