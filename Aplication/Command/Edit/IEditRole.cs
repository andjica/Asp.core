using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command;
using Aplication.Dto.Role;
using Aplication.Interface;

namespace Aplication.Command.Edit
{
    public interface IEditRole : ICommand<RoleDto>
    {
    }
}
