using System;

namespace lfeigl.cleanr.Library
{
    public abstract class Base
    {
        public Guid ID;

        public Base()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
