using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Auctioner;
namespace Aplication.Command.Show
{
    public interface IShowAuctioner : ICommand<int, AuctionerOne>
    {
    }
}
