using System;
using EfDataAccess;
namespace EfCommands
{
    public class EfBase
    {
       protected AuctionContext Context { get; }

        public EfBase(AuctionContext context)
        {
            Context = context;
        }
    }
}
