using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{   
    public class MaxAggregation : Aggregation
    {
        public override Object GetAggregatedValue(List<Cell> cells)
        {
            double max = Double.MinValue;
            foreach(Cell cell in cells)
            {
                try
                {
                    if ((double)cell.Content > max) max = (double)cell.Content;
                }
                catch (BadColumnForThisOperationException)
                {
                    throw;
                }
            }
            return max;
        }

        public MaxAggregation()
        {
        }

        public override string ToString()
        {
            return "max";
        }
    }
}
