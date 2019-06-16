using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Auction;
using Aplication.Command.Add;
using EfDataAccess;
using Aplication.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands.EfAdd
{
    public class EfAddAuction : EfBase, IAddAuction
    {
        public EfAddAuction(AuctionContext context) : base(context)
        {
        }

        public void Execute(AddAuctionDto request)
        {
            if (!Context.Auctioners.Any(a => a.Id == request.AuctionerId))
            {
                throw new EntityNotFound("Auctioner");
            }

            if (!Context.Goods.Any(g => g.Id == request.GoodId))
            {
                throw new EntityNotFound("Good");
            }

            //Proveravamo da li je cena sto je pristigla u requestu manja od cene u tabeli Goods
            //ako je manja bacamo exception

           /* if (request.MaxPrice.HasValue)
            {
                var id = Context.Auctions.Find(request.GoodId);

                

                if (Context.Goods.Any(g => g.FirstPrice <= request.MaxPrice.Value))
                {
                    throw new EntityAlreadyExist("First price");
                }

            }*/

        


            //proveravamo da li je user vec napravion aukciju za jedan jedinstven proizvod
            //ako vec jeste napravio bacamo exception
            /* if (Context.Auctions.Any(a => a.AuctionerId == request.AuctionerId))
            {

                /*if (request.GoodId != null)
                {
                    if (Context.Auctions.Where(c => c.GoodId == request.GoodId))
                    {

                    }
                }
                

            }*/


            

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
