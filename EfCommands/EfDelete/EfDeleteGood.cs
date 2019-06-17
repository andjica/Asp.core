using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteGood : EfBase, IDeleteGood
    {
        public EfDeleteGood(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var good = Context.Goods.Find(request);

            if (good == null)
            {
                throw new EntityNotFound("Good");
            }

            Context.Goods.Remove(good);
            Context.SaveChanges();
        }
    }
}
