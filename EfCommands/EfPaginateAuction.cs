using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Auction;
using Aplication.Response;
using Aplication.SearchEntity.Auction;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands
{
    public class EfPaginateAuction : EfBase, IPaginateAuctions
    {
        public EfPaginateAuction(AuctionContext context) : base(context)
        {
        }

        public PagedResponse<AuctionGoodAuctioner> Execute(SearchAuctionP request)
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
            //sortiramo po imenu Usera koji je napravio Aukciju
            if (request.NameOFAuctioner != null)
            {
                var name = request.NameOFAuctioner.ToLower();

                auction = auction.Where(a => a.Auctioner.FirstName.ToLower().Contains(name));
            }

            var totalCount = auction.Count();

            auction = auction.Skip((request.PageNumber - 1) * request.PerPage)
                             .Take(request.PerPage);


            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var respones = new PagedResponse<AuctionGoodAuctioner>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = auction.Select(a => new AuctionGoodAuctioner
                {
                    Id = a.Id,
                    GoodId = a.Good.Id,
                    GoodTtile = a.Good.Title,
                    GoodCreateAt = a.Good.CreatedAt,
                    GoodFirstPrice = a.Good.FirstPrice,
                    AuctionerId = a.AuctionerId,
                    AuctionerFirstName = a.Auctioner.FirstName,
                    AuctionerLastName = a.Auctioner.LastName,
                    MaxPrice = a.MaxPrice,
                    ValidUntil = a.ValidUntil

                })
            };
            return respones;


        }
    }
}

