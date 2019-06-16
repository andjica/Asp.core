using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Aplication.Command.Show;
using Aplication.Dto;
using Aplication.Dto.Category;
using Aplication.SearchEntity.Category;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Aplication.Dto.Good;
using Aplication.Exceptions;
namespace EfCommands
{
    public class EfShowCategoryGood : EfBase, IShowCategoryGood
    {
        public EfShowCategoryGood(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<CategoryGoodDto> Execute(SearchCategoryGood request)
        {
            var categories = Context.Categories.AsQueryable();


            if (request.Keyword != null)
            {
                var keyword = request.Keyword.ToLower();
                categories = categories.Where(c => c.Title.ToLower().Contains(keyword));
            }
            

            if (request.CategoryId != null)
            {
                categories = categories.Where(c => c.Id == request.CategoryId);
            }

            //odma na pocetku prikazacemo samo aktivne kategorije
            if (request.Active == null)
            {
                categories = categories.Where(c => c.IsDeleted == false);
            }

            return categories.Select(c => new CategoryGoodDto
            {
                Id = c.Id,
                Title = c.Title,
                GoodImageDtos = c.Goods.Select(g => new GoodImageDto {
                    Title = g.Title,
                    Description = g.Description,
                    FirstPrice = g.FirstPrice,
                    CreatedAt = g.CreatedAt,
                    Url = g.Images.Select(i => i.Url).FirstOrDefault()
                }).ToList()
            });
        }
    }
}
