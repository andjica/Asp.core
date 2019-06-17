using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteAuction : EfBase, IDeleteAuction
    {
        public EfDeleteAuction(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var auction = Context.Auctions.Find(request);

            if (auction == null)
            {
                throw new EntityNotFound("Auction");
            }

            Context.Auctions.Remove(auction);
            Context.SaveChanges();
        }
    }
}
