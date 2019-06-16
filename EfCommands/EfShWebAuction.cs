using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Auction;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands
{
    public class EfShWebAuction : EfBase, IShWebAuction
    {
        public EfShWebAuction(AuctionContext context) : base(context)
        {
        }

        public AuctionGoodAuctioner Execute(int request)
        {
            var auction = Context.Auctions.AsQueryable();
            //proba
            auction = auction.Where(a => a.Id == request).Include(a => a.Auctioner).Include(a => a.Good);

            return auction.Select(a => new AuctionGoodAuctioner
            {
                Id = a.Id,
                GoodTtile = a.Good.Title,
                GoodCreateAt = a.Good.CreatedAt,
                GoodId = a.Good.Id,
                GoodFirstPrice = a.Good.FirstPrice,
                AuctionerFirstName = a.Auctioner.FirstName,
                AuctionerLastName = a.Auctioner.LastName,
                AuctionerId = a.Auctioner.Id,
                MaxPrice = a.MaxPrice,
                ValidUntil = a.ValidUntil
            }).FirstOrDefault();
        }
    }
}
