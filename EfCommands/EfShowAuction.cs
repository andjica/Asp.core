using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exceptions;
using Aplication.Dto.Auction;
using Aplication.Command.Show;
using EfDataAccess;
using System.Linq;
using Aplication.Interface;

namespace EfCommands
{
    public class EfShowAuction : EfBase, IShowAuction
    {
        public EfShowAuction(AuctionContext context) : base(context)
        {
        }

        public AuctionDto Execute(int request)
        {
            var auction = Context.Auctions.Find(request);

            if (auction == null)
            {
                throw new EntityNotFound("Auction");
            }

            return new AuctionDto
            {
                Id = auction.Id,
                AuctionerId = auction.AuctionerId,
                GoodId = auction.GoodId,
                MaxPrice = auction.MaxPrice,
                ValidUntil = auction.ValidUntil
            };
        }
    }
}
