using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Exceptions
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(string entity) : base($"This {entity} doesn't exist")
        { }

        public EntityNotFound()
        { }
    }
}
