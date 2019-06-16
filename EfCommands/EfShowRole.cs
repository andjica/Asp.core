using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Role;
using Aplication.Interface;
using EfDataAccess;
using System.Linq;
using Aplication.Exceptions;

namespace EfCommands
{
    public class EfShowRole : EfBase, IShowRole
    {
        public EfShowRole(AuctionContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFound("Role");
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

        }
    }
}
