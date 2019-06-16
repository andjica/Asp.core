using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Auction;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Aplication.SearchEntity.Auction;

namespace EfCommands
{
    public class EfShowAuctionGoodAuctioner : EfBase, IShowAuctionGoodAuctioner
    {
        public EfShowAuctionGoodAuctioner(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<AuctionGoodAuctioner> Execute(SearchAuction request)
        {


            var auction = Context.Auctions.Include(a => a.Good).AsQueryable();
               
            //soritranje po imenu proizvoda
            if (request.TitleGood != null)
            {
                var title = request.TitleGood.ToLower();

                auction = auction.Where(a => a.Good.Title.ToLower().Contains(title));
            }

            //soritranje po najvecoj ceni
            if (request.MaxPrice.HasValue)
            {
                auction = auction.Where(a => a.MaxPrice <= request.MaxPrice);
            }

            //sortiranje po najmanjoj ceni
            if (request.MinPrice.HasValue)
            {
                auction = auction.Where(a => a.MaxPrice >= request.MinPrice);
            }

            if (request.NameOFAuctioner != null)
            {
                var name = request.NameOFAuctioner.ToLower();

                auction = auction.Where(a => a.Auctioner.FirstName.ToLower().Contains(name));
            }


            return auction.Select(a => new AuctionGoodAuctioner
            {
                Id = a.Id,
                GoodTtile = a.Good.Title,
                GoodId = a.Good.Id,
                GoodCreateAt = a.Good.CreatedAt,
                GoodFirstPrice = a.Good.FirstPrice,
                AuctionerFirstName = a.Auctioner.FirstName,
                AuctionerLastName = a.Auctioner.LastName,
                AuctionerId = a.Auctioner.Id,
                MaxPrice = a.MaxPrice,
                ValidUntil = a.ValidUntil

            });
        }
    }
}
