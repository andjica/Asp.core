using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Edit;
using Aplication.Dto.Good;
using EfDataAccess;
using System.Linq;
using Aplication.Exceptions;
namespace EfCommands.EfEdit
{
    public class EfEditGood : EfBase, IEditGood
    {
        public EfEditGood(AuctionContext context) : base(context)
        {
        }

        public void Execute(GoodDto request)
        {
            var good = Context.Goods.Find(request.Id);

            if (good == null)
            {
                throw new EntityNotFound("Good");
            }

            if (good.Title != request.Title)
            {
                if (Context.Goods.Any(g => g.Title == request.Title))
                {
                    throw new EntityAlreadyExist("Title");
                }
            }

            if (good.CategoryId != request.CategoryId)
            {
                if (!Context.Categories.Any(c => c.Id == request.CategoryId))
                {
                    throw new EntityNotFound("Category");
                }
            }

            good.Title = request.Title;
            good.Description = request.Description;
            good.CategoryId = request.CategoryId;
            good.FirstPrice = request.FirstPrice;
            good.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
