﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class MinAggregation : Aggregation
    {
        public override Object GetAggregatedValue(List<Cell> cells)
        {
            double min = Double.MaxValue;
            foreach (Cell cell in cells)
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

        public MinAggregation()
        {
        }

        public override string ToString()
        {
            return "min";
        }
    }
}
