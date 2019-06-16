using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Auctioner> Auctioners { get; set; }
    }
}
