using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Role;

namespace Aplication.Command.Add
{
    public interface IAddRole : ICommand<RoleDto>
    {
    }
}
