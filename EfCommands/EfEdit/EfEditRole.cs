using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Role;
using Aplication.Command.Edit;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;

namespace EfCommands.EfEdit
{
    public class EfEditRole : EfBase, IEditRole
    {
        public EfEditRole(AuctionContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFound("Role");
            }

            if (role.Name != request.Name)
            {
                if (Context.Roles.Any(r => r.Name == request.Name))
                {
                    throw new EntityAlreadyExist();
                }
            }

            role.Name = request.Name;
            role.ModifiedAt = DateTime.Now;
            Context.SaveChanges();

        }
    }
}
