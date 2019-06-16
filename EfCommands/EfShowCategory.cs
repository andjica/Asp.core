using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto;
using Aplication.Exceptions;
using System.Linq;
using Aplication.Dto.Good;
using EfDataAccess;
using Aplication.Dto.Category;
namespace EfCommands
{
    public class EfShowCategory : EfBase, IShowCategory
    {
        public EfShowCategory(AuctionContext context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFound("Category");
            }
               

            return new CategoryDto
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description
            };



        }
    }
}
