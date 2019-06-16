using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Good : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal FirstPrice { get; set; }

        public int CategoryId {get; set;}

        public Category Category { get; set; }

        public ICollection<Auction> Auctions { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
