using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Auctioner
{
    public class AuctionerOne
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
