using Aplication.Command.Delete;
using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteRole : EfBase, IDeleteRole
    {
        public EfDeleteRole(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFound("Role");
            }

            Context.Roles.Remove(role);
            Context.SaveChanges();
        }
    }
}
