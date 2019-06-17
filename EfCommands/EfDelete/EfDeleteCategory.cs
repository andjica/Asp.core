using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteCategory : EfBase, IDeleteCategory
    {
        public EfDeleteCategory(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {

            var category = Context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFound("Category");
            }

            Context.Categories.Remove(category);
            Context.SaveChanges();
        }
    }
}
