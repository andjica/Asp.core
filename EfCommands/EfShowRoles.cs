using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Role;
using Aplication.SearchEntity.Role;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands
{
    public class EfShowRoles : EfBase, IShowRoles
    {
        public EfShowRoles(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(SearchRole request)
        {

            var roles = Context.Roles.AsQueryable();

            if (request.Name != null)
            {
                var name = request.Name.ToLower();

                roles = roles.Where(r => r.Name.ToLower().Contains(name));
            }

            if (request.Id.HasValue)
            {
                roles = roles.Where(r => r.Id == request.Id);
            }

            return roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            });
        }
    }
}
