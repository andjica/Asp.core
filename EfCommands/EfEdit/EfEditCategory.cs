using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Edit;
using Aplication.Dto.Category;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands.EfEdit
{
    public class EfEditCategory : EfBase, IEditCategory
    {
        public EfEditCategory(AuctionContext context) : base(context)
        {
        }

        public void Execute(EditCategory request)
        {
            var category = Context.Categories.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFound("Category");
              
            }
            if (category.Title != request.Title)
            {
                if (Context.Categories.Any(c => c.Title == request.Title))
                {
                    throw new EntityAlreadyExist("Category");
                }
            }
           

            category.Title = request.Title;
            category.Description = request.Description;
            category.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
