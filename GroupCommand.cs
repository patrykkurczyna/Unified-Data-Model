using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class GroupCommand : Command
    {
        public GroupCommand(List<Column> groupingColumns, Dictionary<Column,Aggregation> aggregatedColumns)
        {

        }
        public override Table Execute(Table table)
        {
            return new Table("jan",null, new List<Column>());
        }
    }
}
