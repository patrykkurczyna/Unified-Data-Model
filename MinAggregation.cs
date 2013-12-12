using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class MinAggregation : Aggregation
    {
        public override Object GetAggregatedValue()
        {
            double min = Double.MaxValue;
            foreach (Cell cell in this.cells)
            {
                try
                {
                    if ((double)cell.Content < min) min = (double)cell.Content;
                }
                catch (BadColumnForThisOperationException)
                {
                    throw;
                }
            }
            return min;
        }

        public MinAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}
