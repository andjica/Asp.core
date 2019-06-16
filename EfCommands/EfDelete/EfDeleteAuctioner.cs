using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteAuctioner : EfBase, IDelete
    {
        public EfDeleteAuctioner(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var auctioner = Context.Auctioners.Find(request);

            if (auctioner == null)
            {
                throw new EntityNotFound("Auctioner");
            }

            Context.Auctioners.Remove(auctioner);
            Context.SaveChanges();
        }
    }
}
