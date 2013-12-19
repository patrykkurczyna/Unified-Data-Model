using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    [Serializable]
    public class Table
    {
        protected List<Column> columns;
        protected string _name;
        protected Table previous;
        public virtual string Name
        {
            get { return _name; }
        }

        public virtual List<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table()
        {
            this._name = "";
            this.columns = new List<Column>();
            this.previous = null;
        }

        public Table(String _name, Table previous, List<Column> columns = null)
        {
            this._name = _name;
            if (columns == null) this.columns = new List<Column>();
            else this.columns = columns;
            this.previous = previous;
        }

        public virtual void AddColumn(Column column)
        {
            this.columns.Add(column);
        }

        public virtual bool RemoveColumn(Column column)
        {
            return columns.Remove(column);
        }

        public override String ToString()
        {
            String table = this.Name + "\n";
            foreach (Column column in this.columns)
            {
                table += column.ToString();
                table += "\n";
            }
            return table;
        }

        public virtual Table Execute(Command command)
        {
            return command.Execute(this);
        }

        public virtual Table Undo()
        {
            return previous;
        }
        public virtual Table Normalize()
        {
            return null;
        }
    }
}
