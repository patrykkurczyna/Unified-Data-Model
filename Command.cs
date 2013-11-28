using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    abstract class Command
    {
        public abstract Table Execute(Table table);
    }
}
