using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class SumAggregation : Aggregation
    {
        public override Object GetAggregatedValue()
        {
            double sum = 0.0;
            foreach (Cell cell in this.cells)
            {
                try
                {
                    sum += (double)cell.Content;
                }
                catch (BadColumnForThisOperationException)
                {
                    
                    throw;
                }
            }
            return sum;
        }

        public SumAggregation(List<Cell> cells)
        {
            this.cells = cells;
        }
    }
}
