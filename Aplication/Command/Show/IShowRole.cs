using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Role;


namespace Aplication.Command.Show
{
    public interface IShowRole : ICommand <int, RoleDto>
    {
    }
}
