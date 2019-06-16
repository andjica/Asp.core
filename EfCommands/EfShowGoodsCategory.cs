using System;
using System.Collections.Generic;
using System.Text;
using Aplication.SearchEntity.Good;
using Aplication.Command.Show;
using Aplication.Exceptions;
using Aplication.Dto.Good;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands
{
    public class EfShowGoodsCategory : EfBase, IShowGoodsCategory
    {
        public EfShowGoodsCategory(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<GoodCategoryDto> Execute(SearchGood request)
        {
            var goods = Context.Goods.Include(g => g.Category).AsQueryable();

            if (request.Title != null)
            {
                var title = request.Title.ToLower();

                goods = goods.Where(g => g.Title.ToLower().Contains(title));
            }

            if (request.CategoryId != null)
            {
                goods = goods.Where(g => g.CategoryId == request.CategoryId);
            }

            return goods.Select(g => new GoodCategoryDto
            {
               Id = g.Id, 
               Title = g.Title,
               Description = g.Description,
               FirstPrice = g.FirstPrice,
               CategoryId = g.Category.Id,
               CategoryTitle = g.Category.Title
            });

           
          
        }
    }
}
