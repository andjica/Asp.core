using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Role
{
    public  class RoleDto
    {
        public int Id { get; set; }

        [StringLength(45, ErrorMessage = "Max characters for Role Name is 45")]
        public string Name { get; set; }
    }
}
