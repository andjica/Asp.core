
using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Category;
using Aplication.Command.Show;
using Aplication.SearchEntity.Category;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace EfCommands
{
    public class EfShowCategories : EfBase, IShowCategories
    {
        public EfShowCategories(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(SearchCategories request)
        {
            var categories = Context.Categories.AsQueryable();

            if (request.CategoryId != null)
            {
                categories = categories.Where(c => c.Id == request.CategoryId);
            }

            if (request.Active)
            {
                categories = categories.Where(c => c.IsDeleted == false);
            }

            if (request.Keyword != null)
            {
                var keyword = request.Keyword.ToLower();
                categories = categories.Where(c => c.Title.ToLower().Contains(keyword));
            }

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description
            });
        }
    }
}
