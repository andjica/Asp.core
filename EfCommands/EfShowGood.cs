using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Aplication.Command.Show;
using Aplication.Exceptions;
using Aplication.Dto.Good;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
namespace EfCommands
{
    public class EfShowGood : EfBase, IShowGood
    {
        public EfShowGood(AuctionContext context) : base(context)
        {
        }

        public GoodImageDto Execute(int request)
        {
            //var good = Context.Goods.Find(request);

            var good = Context.Goods.AsQueryable();

            //moze i bez include Images
            good = good.Where(g => g.Id == request).Include(g => g.Category).Include(g => g.Images).AsQueryable();

            if (good == null)
            {
                throw new EntityNotFound("Good");
            }


            return good.Select(g => new GoodImageDto
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                CategoryName = g.Category.Title,
                Url = g.Images.Select(i => i.Url).FirstOrDefault(),
                FirstPrice = g.FirstPrice
            }).FirstOrDefault();
        }
    }
}
