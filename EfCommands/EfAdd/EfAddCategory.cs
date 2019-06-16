using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Dto.Category;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
namespace EfCommands.EfAdd
{
    public class EfAddCategory : EfBase, IAddCategory
    {
        public EfAddCategory(AuctionContext context) : base(context)
        {
        }

     

        public void Execute(AddCategoryDto request)
        {
            if (Context.Categories.Any(c => c.Title == request.Title))
            {
                throw new EntityAlreadyExist("Category");
            }

            Context.Categories.Add(new Domen.Category
            {
                Title = request.Title,
                Description = request.Description

            });

            Context.SaveChanges();
        }
    }
}
