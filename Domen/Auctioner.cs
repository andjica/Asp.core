using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Auctioner : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId {get; set;}

        public Role Role { get; set; }

        public ICollection<Auction> Auctions { get; set; }

     
    }
}
