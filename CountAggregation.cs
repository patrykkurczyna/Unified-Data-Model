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
            return cells.Count;
        }

        public CountAggregation()
        {
        }
    }
}