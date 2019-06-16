using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Auction;
namespace Aplication.Command.Add
{
    public interface IAddAuction : ICommand<AddAuctionDto>
    {
    }
}
