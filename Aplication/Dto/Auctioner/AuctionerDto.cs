using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Auctioner
{
    public class AuctionerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Role { get; set; }
    }
}
