using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Auctioner;
using Aplication.SearchEntity.Auctioner;
namespace Aplication.Command.Show
{
    public interface IShowAuctioners : ICommand<SearchAuctioner, IEnumerable<AuctionerDto>>
    {
    }
}
