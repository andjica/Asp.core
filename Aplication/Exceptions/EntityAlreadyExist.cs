using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Exceptions
{
    public class EntityAlreadyExist : Exception
    {
        public EntityAlreadyExist(string entity) : base($"This {entity} already exist.")
        { }

        public EntityAlreadyExist()
        { }
    }
}
