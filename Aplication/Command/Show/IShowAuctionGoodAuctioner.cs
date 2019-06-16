using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Auction;
using Aplication.Interface;
using Aplication.SearchEntity.Auction;
namespace Aplication.Command.Show
{
    public interface IShowAuctionGoodAuctioner : ICommand<SearchAuction, IEnumerable<AuctionGoodAuctioner>>
    {
    }
}
