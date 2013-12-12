using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{   
    public class MaxAggregation : Aggregation
    {
        public override Object GetAggregatedValue()
        {
            double max = Double.MinValue;
            foreach(Cell cell in this.cells)
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

        public MaxAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}
