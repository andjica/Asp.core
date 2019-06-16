using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Auction;

namespace Aplication.Command.Show
{
    public interface IShWebAuction : ICommand<int, AuctionGoodAuctioner>
    {
    }
}
