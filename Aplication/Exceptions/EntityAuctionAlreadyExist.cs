using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Exceptions
{
    public class EntityAuctionAlreadyExist : Exception
    {
        public EntityAuctionAlreadyExist(string entity) : base($" {entity}")
        { }

        public EntityAuctionAlreadyExist()
        { }
    }
}
