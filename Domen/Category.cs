using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Good> Goods { get; set; }
    }
}
