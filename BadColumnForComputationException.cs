using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class BadColumnForComputationException : Exception
    {
        public BadColumnForComputationException() : base("Nie można wyliczać kolumn typu WYMIAR") { }
    }
}
