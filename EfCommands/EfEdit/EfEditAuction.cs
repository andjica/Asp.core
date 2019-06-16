using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Edit;
using Aplication.Exceptions;
using Aplication.Dto.Auction;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands.EfEdit
{
    public class EfEditAuction : EfBase, IEditAuction
    {
        public EfEditAuction(AuctionContext context) : base(context)
        {
        }

        public void Execute(EditAuction request)
        {
            var auction = Context.Auctions.Find(request.Id);

            if (auction.AuctionerId != request.AuctionerId)
            {
                if (!Context.Auctioners.Any(a => a.Id == request.AuctionerId))
                {
                    throw new EntityNotFound("Auctioner");
                }
            }

            if (auction.GoodId != request.GoodId)
            {
                if (!Context.Goods.Any(a => a.Id == request.GoodId))
                {
                    throw new EntityNotFound("Good");
                }
            }
            

            auction.AuctionerId = request.AuctionerId;
            auction.GoodId = request.GoodId;
            auction.MaxPrice = request.MaxPrice;
            auction.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
