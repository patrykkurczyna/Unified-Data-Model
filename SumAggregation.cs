using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class SumAggregation : Aggregation
    {
        public override Object GetAggregatedValue(List<Cell> cells)
        {
            double sum = 0.0;
            foreach (Cell cell in cells)
            {
                try
                {
                    sum += (int)cell.Content;
                } catch (InvalidCastException e)
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

        public SumAggregation()
        {
        }
    }
}
