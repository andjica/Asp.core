using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Auctioner
{
    public class AddAuctionerDto
    {
        [Required]
        [StringLength(25, ErrorMessage = "Max characters for First name is 25")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Max characters for Last name is 25")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email must be in format Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Max characters for Password is 30")]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
