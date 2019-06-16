using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Edit;
using Aplication.Dto.Auctioner;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;

namespace EfCommands.EfEdit
{
    public class EfEditAuctioner : EfBase, IEditAuctioner
    {
        public EfEditAuctioner(AuctionContext context) : base(context)
        {
        }

        public void Execute(EditAuctioner request)
        {
            var auctioner = Context.Auctioners.Find(request.Id);

            if (auctioner == null)
            {
                throw new EntityNotFound("Auctioner");
            }

            if (auctioner.RoleId != request.RoleId)
            {
                if (!Context.Roles.Any(r => r.Id == request.RoleId))
                {
                    throw new EntityNotFound("Role");
                }
            }

            if (auctioner.Email != request.Email)
            {
                if (Context.Auctioners.Any(a => a.Email == request.Email))
                {
                    throw new EntityAlreadyExist("Email");
                }
            }

            auctioner.FirstName = request.FirstName;
            auctioner.LastName = request.LastName;
            auctioner.Email = request.Email;
            auctioner.Password = request.Password;
            auctioner.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
