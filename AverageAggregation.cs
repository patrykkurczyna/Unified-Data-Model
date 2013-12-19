using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class AverageAggregation : Aggregation
    {
        public override Object GetAggregatedValue(List<Cell> cells)
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
            return sum / this.cells.Count;
        }

        public AverageAggregation()
        {
        }
    }
}
