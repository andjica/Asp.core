using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Auctioner;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;

namespace EfCommands
{
    public class EfShowAuctioner : EfBase, IShowAuctioner
    {
        public EfShowAuctioner(AuctionContext context) : base(context)
        {
        }

        public AuctionerOne Execute(int request)
        {

            var auctioner = Context.Auctioners.Find(request);

            if (auctioner == null)
            {
                throw new EntityNotFound("Auctioner");
            }

            return new AuctionerOne
            {
                Id = auctioner.Id,
                FirstName = auctioner.FirstName,
                LastName = auctioner.LastName,
                Email = auctioner.Email,
                CreatedAt = auctioner.CreatedAt,
               
            };
            
            
        }
    }
}
