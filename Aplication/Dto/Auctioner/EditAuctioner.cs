using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Auctioner
{
    public class EditAuctioner

    {
        public int Id { get; set; }

        [StringLength(25, ErrorMessage = "Max characters for First name is 25")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Max characters for Last Name is 25")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "Max characters for Password is 30")]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
