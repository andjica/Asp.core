using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Exceptions;
using Aplication.Dto.Auction;
using EfDataAccess;

namespace EfCommands.EfAdd
{
    public class EfAddWAuction : EfBase, IAddWebAuction
    {
        public EfAddWAuction(AuctionContext context) : base(context)
        {
        }

        public void Execute(AddWAuction request)
        {
            Context.Auctions.Add(new Domen.Auction
            {
                AuctionerId = request.AuctionerId,
                GoodId = request.GoodId,
                ValidUntil = DateTime.Now.AddDays(15),
                MaxPrice = request.MaxPrice
            });

            Context.SaveChanges();
        }
    }
}
