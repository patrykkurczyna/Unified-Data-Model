using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class CountAggregation : Aggregation
    {
        public override Object GetAggregatedValue(List<Cell> cells)
        {
            return (double)cells.Count;
        }

        public CountAggregation()
        {
        }

        public override string ToString()
        {
            return "ilość";
        }
    }
}