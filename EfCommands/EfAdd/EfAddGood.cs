using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Dto.Good;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.EfAdd
{
    public class EfAddGood : EfBase, IAddGood
        
    {
        public EfAddGood(AuctionContext context) : base(context)
        {
        }

        public void Execute(GoodDto request)
        {

            if (!Context.Goods.Any(g => g.CategoryId == request.CategoryId))
            {
                throw new EntityNotFound("Category");
            }

            if (Context.Goods.Any(g => g.Title == request.Title))
            {
                throw new EntityAlreadyExist("Title");
            }

            Context.Goods.Add(new Domen.Good
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                FirstPrice = request.FirstPrice

            });

            Context.SaveChanges();
        }
    }
}
