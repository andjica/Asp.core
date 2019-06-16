using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Dto.Role;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;

namespace EfCommands.EfAdd
{
    public class EfAddRole : EfBase, IAddRole
    {
        public EfAddRole(AuctionContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            if (Context.Roles.Any(r => r.Name == request.Name))
            {
                throw new EntityAlreadyExist("Category name");
            }

            Context.Roles.Add(new Domen.Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
            
        }
    }
}
