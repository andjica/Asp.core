using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exceptions;
using Aplication.Dto.Auction;
using Aplication.Command.Show;
using EfDataAccess;
using System.Linq;
using Aplication.Interface;
using Microsoft.EntityFrameworkCore;
namespace EfCommands
{
    public class EfShowAuction : EfBase, IShowAuction
    {
        public EfShowAuction(AuctionContext context) : base(context)
        {
        }

        public AuctionDto Execute(int request)
        {
            var auction = Context.Auctions.AsQueryable();

            auction = auction.Where(a => a.Id == request).Include(a => a.Auctioner).Include(g => g.Good).AsQueryable();
            if (auction == null)
            {
                throw new EntityNotFound("Auction");
            }

            return auction.Select(a => new AuctionDto
            {
                Id = a.Id,
                AuctionerId = a.AuctionerId,
                FirstName = a.Auctioner.FirstName,
                LastName = a.Auctioner.LastName,
                GoodId = a.GoodId,
                GoodTitle = a.Good.Title,
                MaxPrice = a.MaxPrice,
                CreateAt = a.CreatedAt,
                ValidUntil = a.ValidUntil
            }).FirstOrDefault();
        }
    }
}
