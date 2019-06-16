using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.SearchEntity.Role;
using Aplication.Dto.Role;

namespace Aplication.Command.Show
{
    public interface IShowRoles : ICommand<SearchRole, IEnumerable<RoleDto>>
    {
    }
}
